
function homer() {
	location.href = location.origin
}

function initIndex() {
	stickyHeader()
	setEventHandlers()
	if (_Detail.userId === undefined || _user.id === undefined) initiateUser()
	setTimeout(() => {
		chAuth()
		loader.addClass('hidden')
	}, 200);
	//alert("This has been called")
}

function showAddCatalogForm() {
	$('.add-catalog-form').removeClass('hidden')
}

function removeDOMById(markupId) {
	$(`#${markupId}`).remove()
}

function removeDOMByClassname(classname) {
	$(`.${classname}`).remove()
}

function removeClassById(markupId) {
	$('.ni-options-wrapper').fadeOut(150)
	$(`#${markupId}`).removeClass('notification_not_read')
}

function removeAllClasses(markupId) {
	//$('.ni-options-wrapper').fadeOut(150)
	$(`.notification-item`).removeClass('notification_not_read')
}

function addClassById(markupId) {
	$(`#${markupId}`).addClass('notification_not_read')
}

function showNdpnCard(markupId, markup, elementReference) {
	$('.notification-detail-card').remove()
	var eventPointer = globalEventPointer
	$('.notification-panel').append(markup)
	$('.ndpn-card').removeClass('hidden')
	$('.ndpn-card').get(0).style.top = (getComputedStyle($('.notification-panel').get(0)).height.replace('px', '') / 2 - $(`#${markupId}`).get(0).offsetHeight) + 'px'
	isNPDetailOpen = true
}

function showNdpgCard(markupId, markup, elementReference) {
	$('.notification-detail-card').remove()
	var eventPointer = globalEventPointer
	$('.notification-page').append(markup)
	$('.ndpg-card').removeClass('hidden')
	$('.ndpg-card').get(0).style.top = (innerHeight / 2 - $(`#${markupId}`).get(0).offsetHeight) + 'px' // + ($(`#${markupId}`).get(0).offsetHeight - (eventPointer.screenY - $(`#${markupId}`).get(0).offsetTop)) + 'px'
	isNPDetailOpen = true
}

var globalRoot = {
	dispose: () => {}
}

async function renderNotificationPanel(request) {
	
	request.then(async (notifications) => {
		let npWrapper = document.getElementById('np_wrapper');
		if (npWrapper == null || npWrapper == undefined || !npWrapper) return
		
		// Note: Dynamic root components are not fully supported in Blazor Server
		// This feature requires Blazor WebAssembly or additional configuration
		try {
			const rootComponent = await window.Blazor.rootComponents.add(npWrapper, 'fl-notification-panel', {
				Notifications: notifications//.slice(0, 10)
			})
			//console.log(rootComponent)
			globalRoot = rootComponent
		} catch (error) {
			console.warn('Could not add dynamic component:', error.message);
			// Fallback: Component should be rendered server-side instead
		}
		
		if (isNPOpen) {
			$('.notification-panel').show()
		}
		//console.log(notifications, 89)
	})
	//rootComponent.dispose()
}


function reRenderNotificationPanel() {
	if (isNPDetailOpen) {
		return;
	}
	// Skip if user is not logged in or accountId is not available
	if (!_Detail || !_Detail.id || _Detail.id === undefined || !Token) {
		return;
	}
	let request = getAccountNotifications(_Detail.id, Token)
	if (!request) return; // Skip if getAccountNotifications returned early
	try {
		globalRoot.dispose()
	} catch (e) {
		console.info(e)
	}
	renderNotificationPanel(request);
}

window.editorsContent = "";

window.getContent = function () {
	return editorsContent
}

var ContentEditor = "";

window.getContentEditor = function () {
	return $('#content_editor')
}

window.setContent = function (val) {
	editorsContent = val
}


function loadKendoUI() {

	$.getScript("../assets/vendors/kendo-ui/jszip.min.js", function (data, textStatus, jqxhr) {
		console.log(textStatus, jqxhr.status, "Load was performed.");
		$.getScript("../assets/vendors/kendo-ui/kendo.all.min.js", function (data, textStatus, jqxhr) {
			console.log(textStatus, jqxhr.status, "Load was performed.");
			loadKendoEditor()
		});
	});

	//$.getScript("/../assets/vendors/test.js", function (data, textStatus, jqxhr) {
	//	console.log(textStatus, jqxhr.status, "Load was performed.");
	//});
}

function loadKendoEditor() {
	$('.kendo-editor-section').load("templates/editor.html");
}

function showNotificationBadgeBig(count) {
	if (count > 99) count = 99;
	if (count <= 0) {
		$('.notification-bage').remove()
		return
	}
	var string = `<div class="notification-bage">${count}</div>`
	$('.notification-bage').remove()
	$('.un_link').append(string)
}

function showNotificationBadgeSmall(count) {
	if (count > 99) count = 99;
	if (count <= 0) {
		$('.notification-bage-mini').remove()
		return
	}
	var string = `<div class="notification-bage-mini"></div>`
	$('.notification-bage-mini').remove()
	$('#notif_btn').append(string)
	if (val == true) {
		//$('.notification-bage-mini').remove()
	}
}

function showMiniContextMenu(markupId) {
	$(`#${markupId} > .ni-options-wrapper`).fadeIn(200)
}

function initCatalogPage(catalogId, userId) {

	getEngagements(userId, getUserToken)

	var cw_modal = $('.cw'),
		cw_video_box = $('.cw-video-box'),
		cw_name = $('.cw-name'),
		vid_desc = $('.vid-desc'),
		vid_caption = $('.vid-caption'),
		engage_btn = $('.engage-user-btn')

	$('.cw-video-box iframe').removeAttr('width')
	$('.cw-video-box iframe').removeAttr('height')
	$('.cw-video-box iframe').css('width', `560px`)
	$('.cw-video-box iframe').css('height', `315px`)

	if (EngagementsUserIdList.includes(userId.toString())) {
		console.log(EngagementsUserIdList)
		//disableEngageBtn()
	}

	getEngagementUserCatalogIdList(catalogId, userId, getUserToken(), () => {
		if (EngagementUserCatalogIdList.includes(catalogId.toString())) {
			console.log(EngagementUserCatalogIdList)
			disableEngageBtn()
		}
	})

	engage_btn.off('click')
	engage_btn.click((e) => {
		loader.removeClass('hidden')
		engageUser(catalogId, userId)
	})

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

	function engageUser(catalogId, userId) {
		engageRequest(new Engagement(userId, catalogId), Token, () => {
			disableEngageBtn()
		})
	}

	if (_Detail.userId === undefined || _user.id === undefined) initiateUser()
	setEventHandlers()
	entryValidityCheck()
	stickyHeader()
	chAuth()

	hideLoader()
}

function initCatalogs() {

	hideLoader();
	if (_Detail.userId === undefined || _user.id === undefined) initiateUser()
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

	//getCatalogs(Token, gt)

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
		$('.save-cat- btn').click(function (e) {
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
			//$('.add-catalog-form').removeClass('hidden')
		}
	}, 200);
}

function disengageUser(engagement) {
	makeGrid('engaged-list')
	/* engagement.engagedDate = new Date(engagement.engagedDate)
	console.log(engagement) */
	disengageRequest(engagement, Token, (response) => {
		//disableEngageBtn()
		popUpBox('done', response.message)
		hideLoader()
	})
}

function initDashboard() {
	function thisFunction() {
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
					_user.dateOfBirth = val
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

	if (_Detail.userId === undefined || _user.id === undefined) {
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
	if (_Detail.userId === undefined || _user.id === undefined) initiateUser()
	setTimeout(() => {
		chAuth()
		loader.addClass('hidden')
	}, 200);
}

function initAdminPanel() {
	stickyHeader()
	setEventHandlers()
	if (_Detail.userId === undefined || _user.id === undefined) initiateUser()
	setTimeout(() => {
		chAuth()
		loader.addClass('hidden')
	}, 200);
}

function changeToContinue(guid) {
	$('.course-detail-page-header .right-section button.enroll-user-btn').remove()
	$('.course-detail-page-header .right-section a.enroll-user-btn').remove()
	$('.course-detail-page-header .right-section').append(`
                    <a class="enroll-user-btn btn-type btn-large header-btn " href="/course/${guid}" >Continue</a>`)
}

function requireLogin() {
	if (_Detail.userId === undefined || _user.id === undefined) {
		initiateUser(function () {
			loader.addClass('hidden')
		}, function () {
			loadSignin()
		})
		return
	}
}

function initCourseDetail() {
	loader.addClass('hidden')
	if (_Detail.userId === undefined || _user.id === undefined) {
		initiateUser(function () {
			//thisFunction()
			chAuth()
			stickyHeader()
			setEventHandlers()
		}, function () {
			//location.href = location.origin
		})
		return
	}
}

function initCourseCompletedPage() {
	if (_Detail.userId === undefined || _user.id === undefined) {
		initiateUser(function () {
			//thisFunction()
			chAuth()
			stickyHeader()
			setEventHandlers()
			loader.addClass('hidden')
		}, function () {
			//location.href = location.origin
		})
		return
	}
}
function initResetPage() {
	chAuth()
	stickyHeader()
	setEventHandlers()
	entryValidityCheck()
	loader.addClass('hidden')
}

function initCoursePage() {
	loader.addClass('hidden')
	if (_Detail.userId === undefined || _user.id === undefined) {
		initiateUser(function () {
			//thisFunction()
			chAuth()
			stickyHeader()
			setEventHandlers()
		}, function () {
			location.href = location.origin
		})
		return
	}
}

