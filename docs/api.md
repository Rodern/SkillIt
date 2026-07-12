# API Documentation

## Base URL

- **Development**: `https://localhost:7001/api/v1`
- **Production**: `https://api.skillit.com/api/v1`

## Authentication

All protected endpoints require a JWT Bearer token in the Authorization header:

```
Authorization: Bearer {your_jwt_token}
```

### Getting a Token

```http
POST /api/Authenticate
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "your_password"
}
```

**Response:**
```json
{
  "success": true,
  "message": "eyJhbGciOiJIUzI1NiIs...",
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

## Pagination

List endpoints support pagination with query parameters:

- `pageNumber` - Page number (default: 1)
- `pageSize` - Items per page (default: 20, max: 100)

**Example:**
```http
GET /api/v1/courses?pageNumber=1&pageSize=20
```

**Response Format:**
```json
{
  "pageNumber": 1,
  "pageSize": 20,
  "totalCount": 150,
  "totalPages": 8,
  "hasPreviousPage": false,
  "hasNextPage": true,
  "items": [...]
}
```

## Endpoints

### Authentication

#### Login
```http
POST /api/Authenticate
```

**Request:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

#### Request Password Reset
```http
POST /api/CreateOTP/{email}
```

#### Reset Password
```http
POST /api/Reset
```

**Request:**
```json
{
  "userId": 123,
  "otpId": 456,
  "guid": "abc-123-def",
  "otp": 123456,
  "password": "newPassword123"
}
```

### Courses

#### Get All Courses
```http
GET /api/v1/courses?pageNumber=1&pageSize=20
```

**Response:**
```json
{
  "pageNumber": 1,
  "pageSize": 20,
  "totalCount": 50,
  "totalPages": 3,
  "items": [
    {
      "courseId": 1,
      "name": "Introduction to Programming",
      "description": "Learn the basics...",
      "level": "beginner",
      "isPublished": true
    }
  ]
}
```

#### Get Course by ID
```http
GET /api/v1/courses/{id}
```

#### Create Course
```http
POST /api/v1/courses
Authorization: Bearer {token}
```

**Request:**
```json
{
  "name": "Advanced Web Development",
  "description": "Master modern web technologies",
  "level": "advanced",
  "authorId": 1
}
```

**Requires**: Admin or Creator role

#### Update Course
```http
PUT /api/v1/courses/{id}
Authorization: Bearer {token}
```

**Requires**: Admin or Creator role

#### Delete Course
```http
DELETE /api/v1/courses/{id}
Authorization: Bearer {token}
```

**Requires**: Admin role only

#### Get Course Chapters
```http
GET /api/v1/courses/{courseId}/chapters
```

### Users

#### Register User
```http
POST /api/User/AddUser
```

**Request:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "password": "securePassword123",
  "phone": "+237123456789",
  "dob": "1995-01-15",
  "gender": "Male"
}
```

#### Get User
```http
GET /api/User/GetUser
Authorization: Bearer {token}
```

**Request:**
```json
{
  "id": 123
}
```

#### Update User
```http
PUT /api/User/UpdateUser
Authorization: Bearer {token}
```

## Error Responses

### Standard Error Format

```json
{
  "success": false,
  "message": "Error description"
}
```

### HTTP Status Codes

- `200 OK` - Success
- `201 Created` - Resource created
- `400 Bad Request` - Invalid request
- `401 Unauthorized` - Missing or invalid token
- `403 Forbidden` - Insufficient permissions
- `404 Not Found` - Resource not found
- `500 Internal Server Error` - Server error

## Rate Limiting

*(To be implemented)*

- Rate limit: 100 requests per minute
- Burst limit: 200 requests

## Versioning

The API uses URL versioning:
- Current version: `v1`
- Access via: `/api/v1/...`

## Webhooks

*(To be implemented)*

## SDKs

*(To be implemented)*

## Support

For API support:
- Email: api-support@skillit.com
- Documentation: https://docs.skillit.com
- Status: https://status.skillit.com
