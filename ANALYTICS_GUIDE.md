# Analytics Guide

This guide explains how to use the analytics system in SkillIT for tracking user engagement and course performance.

## Overview

The analytics system provides:
- Course view tracking
- Enrollment metrics
- Completion rates
- User engagement metrics
- Trending courses

## API Endpoints

### Track Course View

**Endpoint:** `POST /api/v1/analytics/track/course-view/{courseId}`

**Authentication:** Required

Tracks when a user views a course. Call this when:
- User opens a course detail page
- User starts watching a lesson
- User accesses course content

**Example:**
```javascript
async function trackCourseView(courseId) {
    const response = await fetch(`/api/v1/analytics/track/course-view/${courseId}`, {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${jwtToken}`
        }
    });
    return await response.json();
}
```

**Response:**
```json
{
  "success": true,
  "message": "Course view tracked successfully"
}
```

### Get Course Analytics

**Endpoint:** `GET /api/v1/analytics/course/{courseId}`

**Authentication:** Admin only

Get comprehensive analytics for a specific course.

**Example:**
```javascript
const analytics = await fetch(`/api/v1/analytics/course/123`, {
    headers: { 'Authorization': `Bearer ${jwtToken}` }
}).then(r => r.json());
```

**Response:**
```json
{
  "courseId": 123,
  "totalViews": 1542,
  "totalEnrollments": 387,
  "totalCompletions": 156,
  "completionRate": 40.31,
  "averageProgress": 62.5,
  "lastUpdated": "2026-01-01T12:00:00Z"
}
```

### Get User Engagement

**Endpoint:** `GET /api/v1/analytics/user/engagement`

**Authentication:** Required (returns data for current user)

Get engagement metrics for the authenticated user.

**Example:**
```javascript
const engagement = await fetch('/api/v1/analytics/user/engagement', {
    headers: { 'Authorization': `Bearer ${jwtToken}` }
}).then(r => r.json());
```

**Response:**
```json
{
  "userId": 456,
  "totalCoursesEnrolled": 8,
  "coursesCompleted": 3,
  "coursesInProgress": 5,
  "totalAchievements": 12,
  "totalCertificates": 3,
  "averageCompletionRate": 62.5,
  "lastActivityDate": "2026-01-01T10:30:00Z"
}
```

### Get Trending Courses

**Endpoint:** `GET /api/v1/analytics/trending?topCount=10&daysBack=7`

**Authentication:** Public (no auth required)

Get trending courses based on recent views and activity.

**Parameters:**
- `topCount` (optional): Number of courses to return (default: 10)
- `daysBack` (optional): Number of days to analyze (default: 7)

**Example:**
```javascript
const trending = await fetch('/api/v1/analytics/trending?topCount=5&daysBack=7')
    .then(r => r.json());
```

**Response:**
```json
[
  {
    "courseId": 123,
    "courseName": "Introduction to Python",
    "thumbnailUrl": "/images/python-course.jpg",
    "viewCount": 542,
    "uniqueViewers": 312
  },
  {
    "courseId": 456,
    "courseName": "Advanced JavaScript",
    "thumbnailUrl": "/images/js-course.jpg",
    "viewCount": 421,
    "uniqueViewers": 287
  }
]
```

## Database Schema

### CourseView Table

Stores individual course view events:

```sql
CREATE TABLE course_views (
    view_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    course_id INT NOT NULL,
    viewed_at DATETIME NOT NULL,
    ip_address VARCHAR(45),
    user_agent VARCHAR(500),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (course_id) REFERENCES courses(course_id),
    INDEX idx_course_views_course (course_id, viewed_at),
    INDEX idx_course_views_user (user_id, viewed_at)
);
```

**Migration Command:**
```bash
cd SkillIT-Models
dotnet ef migrations add AddCourseViewsTable
dotnet ef database update
```

## Implementation Examples

### Track Views Automatically (React/Next.js)

```javascript
import { useEffect } from 'react';

function CourseDetailPage({ courseId }) {
    useEffect(() => {
        // Track view when component mounts
        const trackView = async () => {
            try {
                await fetch(`/api/v1/analytics/track/course-view/${courseId}`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${localStorage.getItem('token')}`
                    }
                });
            } catch (err) {
                console.error('Failed to track view:', err);
            }
        };

        trackView();
    }, [courseId]);

    return <div>Course content...</div>;
}
```

### Display User Progress Dashboard (Blazor)

```csharp
@page "/dashboard"
@inject HttpClient Http

<h3>Your Progress</h3>

@if (engagement != null)
{
    <div class="stats-grid">
        <StatCard 
            Title="Courses Enrolled" 
            Value="@engagement.TotalCoursesEnrolled" 
            Icon="📚" />
        <StatCard 
            Title="Completed" 
            Value="@engagement.CoursesCompleted" 
            Icon="✅" />
        <StatCard 
            Title="In Progress" 
            Value="@engagement.CoursesInProgress" 
            Icon="🔄" />
        <StatCard 
            Title="Achievements" 
            Value="@engagement.TotalAchievements" 
            Icon="🏆" />
    </div>
    
    <div class="progress-bar">
        <div class="progress" style="width: @engagement.AverageCompletionRate%">
            @engagement.AverageCompletionRate.ToString("F1")%
        </div>
    </div>
}

@code {
    private UserEngagementMetrics engagement;

    protected override async Task OnInitializedAsync()
    {
        engagement = await Http.GetFromJsonAsync<UserEngagementMetrics>(
            "/api/v1/analytics/user/engagement");
    }
}
```

### Admin Analytics Dashboard

```javascript
function AdminDashboard() {
    const [courseAnalytics, setCourseAnalytics] = useState(null);
    const [courseId, setCourseId] = useState(123);

    useEffect(() => {
        loadAnalytics();
    }, [courseId]);

    async function loadAnalytics() {
        const data = await fetch(`/api/v1/analytics/course/${courseId}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        }).then(r => r.json());
        
        setCourseAnalytics(data);
    }

    if (!courseAnalytics) return <div>Loading...</div>;

    return (
        <div className="analytics-dashboard">
            <h2>Course Analytics</h2>
            
            <div className="metrics">
                <Metric label="Total Views" value={courseAnalytics.totalViews} />
                <Metric label="Enrollments" value={courseAnalytics.totalEnrollments} />
                <Metric label="Completions" value={courseAnalytics.totalCompletions} />
                <Metric 
                    label="Completion Rate" 
                    value={`${courseAnalytics.completionRate.toFixed(1)}%`} 
                />
            </div>

            <ProgressChart averageProgress={courseAnalytics.averageProgress} />
        </div>
    );
}
```

### Trending Courses Widget

```javascript
function TrendingCoursesWidget() {
    const [trending, setTrending] = useState([]);

    useEffect(() => {
        fetch('/api/v1/analytics/trending?topCount=5')
            .then(r => r.json())
            .then(setTrending);
    }, []);

    return (
        <div className="trending-widget">
            <h3>🔥 Trending This Week</h3>
            {trending.map(course => (
                <div key={course.courseId} className="trending-item">
                    <img src={course.thumbnailUrl} alt={course.courseName} />
                    <div>
                        <h4>{course.courseName}</h4>
                        <p>{course.viewCount} views • {course.uniqueViewers} learners</p>
                    </div>
                </div>
            ))}
        </div>
    );
}
```

## Performance Considerations

### Caching

Analytics queries can be expensive. Use caching:

```csharp
var analytics = await cache.GetOrCreateAsync(
    $"analytics_course_{courseId}",
    async entry =>
    {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
        return await analyticsService.GetCourseAnalytics(courseId);
    });
```

### Background Processing

For heavy analytics, consider background processing:

```csharp
// Queue analytics calculation
backgroundJobClient.Enqueue(() => 
    RecalculateCourseAnalytics(courseId));
```

### Database Indexing

Ensure proper indexes exist:

```sql
-- Speed up trending courses query
CREATE INDEX idx_course_views_trending 
ON course_views(viewed_at DESC, course_id);

-- Speed up user engagement query
CREATE INDEX idx_enrollments_user_metrics 
ON course_enrollments(user_id, completion_percentage);
```

## Privacy Considerations

- **IP Addresses**: Optional, anonymize if stored
- **User Agents**: Use for device analytics only
- **GDPR Compliance**: Allow users to request data deletion
- **Aggregation**: Prefer aggregated metrics over individual tracking

## Best Practices

1. **Track Important Events Only** - Don't track every action
2. **Batch Writes** - Consider batching analytics writes for performance
3. **Cache Aggressively** - Analytics don't need real-time accuracy
4. **Archive Old Data** - Move old analytics to archive tables
5. **Monitor Query Performance** - Analytics queries can be slow

## Future Enhancements

Potential additions:
- Heatmaps of course content engagement
- Video watch time analytics
- Quiz performance metrics
- Cohort analysis
- Retention funnels
- A/B testing framework

## Troubleshooting

### Views Not Being Tracked

- Verify user is authenticated
- Check network requests in browser DevTools
- Verify CourseView table exists in database

### Analytics Not Updating

- Check cache expiration settings
- Verify background jobs are running
- Check database connection

### Performance Issues

- Add database indexes
- Increase cache duration
- Use pagination for large result sets
- Consider denormalized analytics tables

## Additional Resources

- [Entity Framework Performance](https://docs.microsoft.com/en-us/ef/core/performance/)
- [Caching in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/)
- [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)
