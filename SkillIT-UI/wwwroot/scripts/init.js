//const BaseURL = 'http://localhost:5000/'
//const BaseURL = 'https://localhost:5001/'
//const BaseURL = 'https://localhost:7165/'
//const BaseURL = 'http://aprilman-001-site1.atempurl.com/'
//const BaseURL = 'https://skillitapi.herokuapp.com/'

const BaseURL = `${location.origin}/`

const skillitUserIPKey = 'skillit_userIP'
const tokenKey = 'skillit_user-token'
const userIdKey = 'skillit_userId'
const userPassKey = 'skillit_user-pass'

let userIPAddress = {
	ip: ''
};

let UserId = ''
let Token = ''
let skill = new Skill()//(9, 'Xamarin.Forms', Level[1])
let userSkill = new UserSkill()//(9, 9, UserId, skill)
let userSkills = new Array();
//userSkills.push(userSkill)

let skillit_UI_name = 'SkillIT-UI'

let previousPageTitle = ''
let pageTitle = ''
let g_header_height
let g_list_height

let isNPOpen = false
let isNPDetailOpen = false

let globalEventPointer

function getPageTitle(val = '') {
	if (val == '') return $('title').text()
	$('title').text(val)
	return $('title').text(val)
}

var globalAlertCancel = document.getElementById('cancelHandler');
var globalAlertConfirm = document.getElementById('alertBtnHandler');

const loader = $('.loading-frame')

let userLocation
getGeoLoc()

let loginInfos = new Array()
let loginAttemps = new Array()

let loginInfo = new LoginInfo()//('userLocation.coords.latitude', 'userLocation.coords.longitude', new Date(), false, true, userIPAddress.ip)
let loginAttemp = new LoginAttemp()//(new Date(), 'Justified', 'success')

//let user = new User(newUserId(), 'T-Rex', 'M', 'Tekoh', 't.rex@outlook.com', 't#rex', new Date(), 'Fundong', new Date(), '679097623', "", loginInfos, loginAttemps)


let social = new Social()//(9, 'Twitter', 'https://twitter/profile');
let userSocial = new UserSocial()//(8, 9, UserId, social)
let userSocials = new Array()


let _Detail = new AccountDetail()
let _user = new User();

let userCredential = new UserCredential()
/* new UserCredential(
	email = "k.n.alain@gmail.com",
	password = "kimbudfgchjvbk",
	rememberMe = false,
	code = "105f3921-3f54-4354-b440-7211d77c84c5"
) */

let isFirst = true

setInterval(() => {
	let skillit_track_key = "skillit_track_key", trackIdey = 'skillit_trackid_key'
	let trackId = parseInt(localStorage.getItem(trackIdey)) || newUserId()
	if (localStorage.hasOwnProperty(skillit_track_key) != true) {
		let visitData = JSON.stringify({ trackId: trackId, hasVisited: true, location: { platform: navigator.platform, userAgent: navigator.userAgent, appVersion: navigator.appVersion, roductSub: navigator.productSub, vendor: navigator.vendor, ip: userIPAddress.ip } })

		navigator.permissions.query({
			name: 'geolocation'
		}).then((permission) => {
			// is geolocation granted?
			if (permission.state === "granted") {
				navigator.geolocation.getCurrentPosition((location) => {
					visitData = JSON.stringify({ trackId: trackId, hasVisited: true, location: { platform: navigator.platform, userAgent: navigator.userAgent, appVersion: navigator.appVersion, roductSub: navigator.productSub, vendor: navigator.vendor, ip: userIPAddress.ip, location: { latitude: location.coords.latitude, longitude: location.coords.longitude, accuracy: location.coords.accuracy, timestamp: location.timestamp } } })
					localStorage.setItem(trackIdey, trackId)
					localStorage.setItem(skillit_track_key, visitData)
					DotNet.invokeMethodAsync(skillit_UI_name, 'SaveVisitor', visitData, trackId, location.origin).then(result => {
						console.log(result)
					})
				})
				return
			}
			visitData = JSON.stringify({ trackId: trackId, hasVisited: true, location: { platform: navigator.platform, userAgent: navigator.userAgent, appVersion: navigator.appVersion, roductSub: navigator.productSub, vendor: navigator.vendor, ip: userIPAddress.ip } })
			localStorage.setItem(trackIdey, trackId)
			localStorage.setItem(skillit_track_key, visitData)
			DotNet.invokeMethodAsync(skillit_UI_name, 'SaveVisitor', visitData, trackId, location.origin).then(result => {
				console.log(result)
			})
		})
		
	}
	reRenderNotificationPanel()
	if (!isFirst) return
	chAuth()
	isFirst = false
}, 5000)

let catalog = new Catalog()//('New version of Jetbrains', 'Have you tried out the new version of JetBrains', 'https://learners.jetbrains.space/d/3MniFw3UDJQg?f=0.jpg', 'learners.jetbrains.space')

let Catalogs = new Array()
let CatalogCaptions = new Array()
let Engagements = new Array()
let EngagementsUserIdList = new Array()
let EngagementUserCatalogIdList = new Array()

window.addEventListener("DOMContentLoaded", () => {
	if ('serviceWorker' in navigator) {
		try {
			//navigator.serviceWorker.register('serviceWorker.js');
			console.info("Succesfully registered Service Worker");
		} catch (error) {
			console.info("Service worker registration failed" + error);
		}
	}
})


if(KeyExists(skillitUserIPKey)){
	try {
		userIPAddress = JSON.parse(getKeyValue(skillitUserIPKey))
	} catch (error) {
		console.info(error)
	}
}

getIP();

function isLoggedIn() {
	if (_Detail.userId === undefined || _user.userId === undefined) {
		return false
	}
	return true
}


setEventHandlers()



