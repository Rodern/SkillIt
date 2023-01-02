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

let previousPageTitle = ''
let pageTitle = ''
let g_header_height
let g_list_height

function getPageTitle(val = '') {
	if (val == '') return $('title').text()
	$('title').text(val)
	return $('title').text(val)
}

var globalAlertCancel = document.getElementById('cancelHandler');
var globalAlertConfirm = document.getElementById('alertBtnHandler');

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
					DotNet.invokeMethodAsync('SkillIT-UI', 'SaveVisitor', visitData, trackId, location.origin).then(result => {
						console.log(result)
					})
				})
				return
			}
			visitData = JSON.stringify({ trackId: trackId, hasVisited: true, location: { platform: navigator.platform, userAgent: navigator.userAgent, appVersion: navigator.appVersion, roductSub: navigator.productSub, vendor: navigator.vendor, ip: userIPAddress.ip } })
			localStorage.setItem(trackIdey, trackId)
			localStorage.setItem(skillit_track_key, visitData)
			DotNet.invokeMethodAsync('SkillIT-UI', 'SaveVisitor', visitData, trackId, location.origin).then(result => {
				console.log(result)
			})
		})
		
	}

	chAuth()
}, 5000)

let catalog = new Catalog()//('New version of Jetbrains', 'Have you tried out the new version of JetBrains', 'https://learners.jetbrains.space/d/3MniFw3UDJQg?f=0.jpg', 'learners.jetbrains.space')

let Catalogs = new Array()
let CatalogCaptions = new Array()
let Engagements = new Array()
let EngagementsUserIdList = new Array()

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

function initIndex() {
	stickyHeader()
	setEventHandlers()
	if (_Detail.userId === undefined || _user.userId === undefined) initiateUser()
	setTimeout(() => {
		chAuth()
		loader.addClass('hidden')
	}, 200);
	//alert("This has been called")
}

function initCatalogs() {
	var cw_modal = $('.cw'),
	cw_video_box = $('.cw-video-box'),
	cw_name = $('.cw-name'),
	vid_desc = $('.vid-desc'),
	vid_caption = $('.vid-caption'),
	engage_btn = $('.engage-user-btn')

	function openCatalog(catalog) {
		cw_name.text(catalog.caption)
		vid_caption.text(catalog.caption)
		cw_video_box.html(JSON.parse(catalog.data).html)
		vid_desc.text(catalog.description)

		$('.cw-video-box iframe').removeAttr('width')
		$('.cw-video-box iframe').removeAttr('height')
		$('.cw-video-box iframe').css('width', `560px`)
		$('.cw-video-box iframe').css('height', `315px`)

		if (EngagementsUserIdList.includes(UserId.toString())) {
			disableEngageBtn()
		}
		cw_modal.fadeIn(100)
		engage_btn.off('click')
		engage_btn.click((e) => {
			loader.removeClass('hidden')
			engageUser(catalog.catalogId)
		})
	}

	function disableEngageBtn() {
		engage_btn.css('filter', 'grayscale(1)')
		engage_btn.text('ENGAGED')
		engage_btn.attr('disabled', '')
	}

	function enableEngageBtn() {
		engage_btn.css('filter', 'grayscale(0)')
		engage_btn.text('ENGAGE')
		engage_btn.removeAttr('disabled')
	}

	function engageUser(catId) {
		engageRequest(new Engagement(_user.userId, catId), Token, () => {
			disableEngageBtn()
			loader.addClass('hidden')
		})
	}

	$('.exit-cw').click(() => {
		cw_modal.fadeOut(100)
	})

	if (_Detail.userId === undefined || _user.userId === undefined) initiateUser()
	let = catList = $('.cat-list')
	function gt(cat_template) {
		try {
			catList.html('')
			Catalogs.forEach(catalog => {
				catList.append(cat_template(catalog)).ready(() => {
					$('.view-cat').off('click')
					$(`#cat_${catalog.catalogId}`).click((e) => {
						let index
						for (i = 0; i < Catalogs.length; i++) {
							if (Catalogs[i].catalogId == parseInt(e.target.id.substring(4))) index = i
						}
						//console.log(Catalogs[index])
						openCatalog(catalog)
					})
				});
			});
			getEngagements(UserId, Token)
			loader.addClass('hidden')
		} catch (error) {
			console.log(error)
		}
	}
	setEventHandlers()
	entryValidityCheck()
	stickyHeader()
	getCatalogs(Token, gt)
	setTimeout(() => {
		chAuth()
		setEventHandlers()
		//loader.addClass('hidden')
		let c_img = $('#catImg')
		let images = null
		let selected = null
		$(c_img).on('change', async () => {
			selected = c_img[0].files
			if (selected === undefined || selected.length == 0) return
			images = new Array(selected[0])
		})
		$('.save-cat-btn').click(function (e) {
			e.preventDefault()
			loader.removeClass('hidden')
			let catalog = new Catalog($('#catCaption').val(), $('#catDesc').val(), '', '', $('#catLink').val())
			if ((catalog.caption == null || catalog.caption == "") || (catalog.description == null || catalog.description == "") /* || c_img[0].files[0] === undefined) */) {
				popUpBox('info', 'There are empty field(s), please check again!', 'catAlert')
				loader.addClass('hidden')
				return
			}
			let res = $.ajax({
				type: 'get',
				url: `https://www.youtube.com/oembed?url=${catalog.catalogLink}`,
				error: (error) => {
					popUpBox('info', 'Unable to get data from url! Reason:' + error.responseText, 'catAlert')
					loader.addClass('hidden')
					catalog.data = ''
				},
				success: (data) => {
					//console.log(data)
				}
			}).done(() => {
				catalog.data = JSON.stringify(res.responseJSON)
				console.log(JSON.stringify(catalog))
				addCatalog(catalog, new File([], 'image', { type: 'image/jpg' }), Token)
				catalog = new Catalog()
				$('input').val('')
				$('textarea').val('')
			})

		})
		if (_Detail.accountType == 'admin') {
			$('.add-catalog-form').removeClass('hidden')
		}
	}, 2000);
}

function initDashboard() {
	function thisFunction() {
		function disengageUser(engagement) {
			makeGrid()
			/* engagement.engagedDate = new Date(engagement.engagedDate)
			console.log(engagement) */
			disengageRequest(engagement, Token, (response) => {
				//disableEngageBtn()
				popUpBox('done', response.message)
				loader.addClass('hidden')
			})
		}
		$(document).click((e) => {
			if (e.target.closest('.e-view-box') != null || e.target.closest('.list-item')) return
			remove_engagement_view_box()
		})
		$(document).scroll((e) => {
			remove_engagement_view_box()
		})
		setTimeout(() => {
			loadDash()
			chAuth()
			setEventHandlers()
			stickyHeader()
			loader.addClass('hidden')
			$('.save-social-btn').click((e) => {
				social = new Social(0, $('#nscn').val(), $('#nscp').val())
				if (social.name == '' || social.link == '') {
					popUpBox('info', 'There are empty field(s), please check again!', 'catAlert')
					return
				}
				userSocial = new UserSocial(0, 0, UserId, social)
				addUserSocial(userSocial, Token)
				$('input').val('')
			})

			$('.p-detail-btn').click((e) => {
				/* $('.user-section').fadeIn(100, (e)=>{
					$('.user-section').css('background-color', 'rgba(0, 0, 0, 0.863)')
				}) */
				$('.user-section').css('background-color', 'rgba(0, 0, 0, 0.863)')
				$('.user-section').removeClass('hidden')
				$('.user-section').addClass('flex')
			})

			$('.exit-cp').click((e) => {
				/* $('.user-section').fadeOut(100, (e) => {
					$('.user-section').show() */
				$('.user-section').addClass('hidden')
				$('.user-section').removeClass('flex')
				$('.user-section').css('background-color', 'rgba(0, 0, 0, 0.507)')
				//})
			})

			$('.save-skill-btn').click((e) => {
				skill = new Skill(0, $('#nskn').val(), $('#nskp').val())
				if (skill.name == '' || skill.level == '') {
					popUpBox('info', 'There are empty field(s), please check again!', 'catAlert')
					return
				}
				let us = new UserSkill(0, 0, UserId, skill)
				let skills = new Array()
				skills.push(us)
				console.log(skills)
				addUserSkills(skills, Token)
				$('input').val('')
			})

			$('#edit-avt').click((e) => {
				info_img_template('image', '.jpg, .png, .raw')
			})

			$('#d_phone').click((e) => {
				function cb(val) {
					_user.phone = val
				}
				info_edit_template('phone', 'tel', 9, 'Enter phone number', cb)
			})

			$('#u_dob').click((e) => {
				function cb(val) {
					_user.dob = val
				}
				info_edit_template('dob', 'date', 100, 'Date', cb)
			})

			$('#u_g').click((e) => {
				function cb(val) {
					_user.gender = val
				}
				info_edit_template('g', 'text', 1, 'M or F', cb)
			})

			$('#u_address').click((e) => {
				function cb(val) {
					_user.address = val
				}
				info_edit_template('add', 'text', 100, 'Address', cb)
			})
		}, 20);
	}

	if (_Detail.userId === undefined || _user.userId === undefined) {
		initiateUser(function () {
			thisFunction()
		}, function () {
			location.href = location.origin
		})
		return
	}
	thisFunction()
}

function initCourses() {
	stickyHeader()
	setEventHandlers()
	if (_Detail.userId === undefined || _user.userId === undefined) initiateUser()
	setTimeout(() => {
		chAuth()
		loader.addClass('hidden')
	}, 200);
}

setEventHandlers()


