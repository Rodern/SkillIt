

function showLoader(callback) {
    loader.removeClass('hidden')
    if (callback) {
        callback()
        return
    }
}

function hideLoader(callback) {
    loader.addClass('hidden')
    if (callback) {
        callback()
        return true
    }
}

function LoadScripts(param1, param2, param3) {
    App.LoadScript('./lib/tailwindcss.js', () => {
        App.LoadScript('./node_modules/tw-elements/dist/js/tw-elements.umd.min.js', () => {
            //setEventHandlers();


            if (param1) {
                let callback = window[param1]
                if (param3) {
                    if (!callback || callback == undefined || callback == null) return
                    callback(param2, param3);
                    console.log('Called on param3')
                    return
                }
                if (param2) {
                    if (!callback || callback == undefined || callback == null) return
                    callback(param2);
                    console.log('Called on param2')
                    return
                }
                callback()
                console.log('Called on no param')
            }
            //hideLoader();
            console.log('Done loading scripts');
        })
    })
}


function popUpBox(boxType, boxMsg, OKCN, cancelCN = "CN_Class", CallBack = function () {
    $(globalAlertConfirm).removeClass(OKCN);
    clearPopUpBox();
}) {
    if (boxType == "done") {
        $('.typeImg').attr('src', 'assets/icons/done.png');
        $('.typeName').text("Done!");
        $('.alertBody').text(boxMsg);
    } else if (boxType == "alert") {
        $('.typeImg').attr('src', 'assets/icons/alert.png');
        $('.typeName').text("Alert");
        $('.alertBody').text(boxMsg);
        $('.alertCancel').show();
    } else if (boxType == "notify") {
        $('.typeImg').attr('src', 'assets/icons/notify.png');
        $('.typeName').text("Notification");
        $('.alertBody').text(boxMsg);
    } else if (boxType == "info") {
        $('.typeImg').attr('src', 'assets/icons/info.png');
        $('.typeName').text("Notification");
        $('.alertBody').text(boxMsg);
    } else if (boxType == "warn") {
        $('.typeImg').attr('src', 'assets/icons/warning.png');
        $('.typeName').text("Warning!");
        $('.alertBody').text(boxMsg);
    } else if (boxType == "error") {
        $('.typeImg').attr('src', 'assets/icons/error.png');
        $('.typeName').text("Error!");
        $('.alertBody').text(boxMsg);
    } else if (boxType == "fail") {
        $('.typeImg').attr('src', 'assets/icons/error.png');
        $('.typeName').text("Failed!");
        $('.alertBody').text(boxMsg);
    }
    $('.alertCover').attr('tabindex', -1).focus(function () {
        //console.log('hit');
    });
    $('.alertCover').on('keyup', function (e) {
        if (e.which === 13 && $('.alertCover').css('display') == 'flex') {
            e.preventDefault();
            CallBack();
        }
    })

    $('.alertCover').fadeIn(150);
    $('.alertCover').css('display', 'flex');

    $(globalAlertConfirm).addClass(OKCN);
    $(globalAlertCancel).addClass(cancelCN);

    $(globalAlertCancel).on('click', function () {
        $(globalAlertConfirm).removeClass(OKCN);
        $(globalAlertCancel).removeClass(cancelCN);
        clearPopUpBox();
    });

    $(globalAlertConfirm).on('click', function () {
        CallBack();
        $(globalAlertConfirm).removeClass(OKCN);
    });
}

function clearPopUpBox() {
    $(globalAlertConfirm).unbind('click')
    $(globalAlertCancel).unbind('click')
    $('.alertCover').unbind('keyup')
    $('.alertCover').fadeOut(150, function () {
        $('.typeImg').attr('src', '');
        $('.typeName').text("");
        $('.alertBody').text("");
        $('.alertCancel').hide();
    });
}

function menuFactory(pageName, isLoggedIn) {
    switch (pageName) {
        case 'home':

            break;

        default:
            break;
    }
}

function entryValidityCheck() {
    $('input').unbind('keyup')
    $('input').keyup((e) => {
        let invalid = $('div.input-wrapper input:not(browser-default):focus:invalid')
        if (invalid.length == 0) {
            $(e.target.parentElement).css('border-color', '#ddd')
            return
        }
        $(e.target.parentElement).css('border-color', 'red')

    })
}

function IsInputInvalid() {
    let invalid = $('div.input-wrapper input:not(browser-default):focus:invalid')
    if (invalid.length == 0) {
        return false
    }
    return true
}

function padTo2Digits(num) {
    return num.toString().padStart(2, '0')
}

function formatDate(date = new Date()) {
    return [
        padTo2Digits(date.getDate()),
        padTo2Digits(date.getMonth() + 1),
        date.getFullYear()
    ].join('-')
}

function IsValid(val) {
    if (val.success == true) console.log(true)
}

var g_img = ''

const KeyExists = (key) => {
    return (localStorage.hasOwnProperty(key))
}

const setKeyValue = (key, val) => {
    localStorage.setItem(key, val)
}

const getKeyValue = (key) => { return localStorage.getItem(key) }

const deleteKey = (key) => { return localStorage.removeItem(key) }

const encodeText = (text) => {
    let encoder = new TextEncoder()
    return encoder.encode(text).toString()
}


function setUrl(url) {
    window.history.pushState(null, null, location.origin + url)
}

const decodeText = (text) => {
    let decoder = new TextDecoder()
    return decoder.decode(Uint8Array.from(text.split(",")));
}

function blobToBase64Ansync(blob) {
    return new Promise((resolve, _) => {
        const reader = new FileReader();
        reader.onloadend = () => resolve(reader.result);
        reader.readAsDataURL(blob);
    });
}

function base64ToBlob(base64, mime) {
    mime = mime || '';
    var sliceSize = 1024;
    var byteChars = window.atob(base64.substring(base64.lastIndexOf(',') + 1));
    var byteArrays = [];
    for (var offset = 0, len = byteChars.length; offset < len; offset += sliceSize) {
        var slice = byteChars.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    return new Blob(byteArrays, { type: mime });
}

function imageToBase64Async(img) {
    return new Promise((resolve, _) => {
        let reader = new FileReader()
        reader.onload = function () {
            resolve(reader.result)
        }
        reader.error = function (error) {
            console.log('Error: ', error)
            popUpBox('error', error)
        }
        reader.readAsDataURL(img)
    })
}

function blobToStringAsync(blob) {
    return new Promise((resolve, _) => {
        let reader = new FileReader()
        let decoder = new TextDecoder()
        reader.onload = () => {
            resolve(decoder.decode(reader.result))
        }
        reader.readAsArrayBuffer(blob)
    })
}

function dataURLtoFile(dataurl, filename) {
    var arr = dataurl.split(',')
    var bstr = atob(arr[0]),
        n = bstr.length,
        u8arr = new Uint8Array(n);

    while (n--) {
        u8arr[n] = bstr.charCodeAt(n);
    }
    return new File([u8arr], filename, { type: 'image/png' });
}

const getIP = () => {
    $.ajax({
        type: 'get',
        url: 'https://api.ipify.org/?format=json',
        error: (error) => {
            //console.info(error.responseText);
        },
        success: (ip) => {
            userIPAddress = ip;
            setKeyValue(skillitUserIPKey, JSON.stringify(ip))
        }
    })
}

const sendResetcode = (email, callback) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/CreateOTP/${email}`,
        error: (error) => {
            console.error(error.responseText);
        },
        success: (response) => {
            if (response.success == true) {
                callback(email)
                setKeyValue('reset-email', email)
                setKeyValue('reset-code', response.message)
                loader.addClass('hidden')
                //popUpBox('notify', 'Check your mail box for the reset code. Donot close this page yet', 'catAlert')
                return
            }
            console.log(response)
            popUpBox('notify', response.message, 'catAlert')
        }
    })
}

const newUserId = () => {
    return Math.floor(Date.now())
}

function TrimSpace(text, pos = 1, UP = false) {
    if (pos == -1)
        return text.trimStart();
    if (pos == 0)
        return text.trimEnd();
    if (pos == 1)
        return text.trim();
}

const getGeoLoc = () => {
    navigator.geolocation.getCurrentPosition((location) => {
        userLocation = location
        console.log(location)
    })
}

const resetPassword = (userCredential, callback) => {
    console.log(JSON.stringify(userCredential));
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Reset`,
        data: JSON.stringify(userCredential),
        dataType: "json",
        contentType: "application/json",
        error: (error) => {
            console.error(error.responseText);
        },
        success: (response) => {
            loader.addClass('hidden')
            if (response.success == true) {
                popUpBox('notify', 'Password reset was successfully. Now login with your new password', 'catAlert', 'caR', callback)
                return
            }
            function cb() {
                exitModal(() => {
                    loadReset()
                })
                clearFlc('floating-content-2')
                clearPopUpBox()
            }
            popUpBox('notify', 'Failed:' + response.message + '<br> Please restart the reset process', 'catAlert', '', cb)
        }
    })
}

function decryptToken(token) {
    let [, infoSection] = token.split('.')
    return JSON.parse(atob(infoSection))
}

function getEmailFromToken(token) {
    let [, infoSection] = token.split('.')
    return JSON.parse(atob(infoSection)).email
}

function getUserId() {
    if (KeyExists(userIdKey) == true) {
        return decodeText(getKeyValue(userIdKey))
    }
    return '0'
}

function getAccountId() {
    if (KeyExists(userIdKey) == true) {
        //alert(_Detail.id);
        return `${_Detail.id}`
    }
    return '0'
}

function getUserToken() {
    if (KeyExists(tokenKey) == true) {
        return decodeText(getKeyValue(tokenKey))
    }
    return '0'
}

function setUser(user) {
    _user = user
    _user.dateOfBirth = new Date(_user.dateOfBirth)
    //console.log(user)
    //getAccount(userId, token)
}

function getUserPassKey() {
    return decodeText(getKeyValue(userPassKey))
}

function setAccount(account) {
    _Detail = detail
}

const IsTokenValid = (token, callback = () => { console.info(" ") }) => {
    let isValid;
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/CheckTokenValidity?token=${token}`,
        data: '',
        success: (responseModel) => {
            if (responseModel.success == true) {
                callback()

                //DotNet.invokeMethodAsync(skillit_UI_name, "MarkAsAuthorized", Token).then(result => {
                //    callback(result)
                //})
                //console.log(responseModel.success)
            }
            else {
                var cred = decryptToken(Token)
                AuthenticateUser(new UserCredential(cred.email, decodeText(getKeyValue(userPassKey)), false, ""))
            }
        }
    })

}

function getTokenExpiryDate(token, callback = (result) => { console.log(result) }) {
    DotNet.invokeMethodAsync(skillit_UI_name, "GetDateFromTokenTicks", decryptToken(Token).exp).then(result => {
        callback(result)
    })
}

function initiateUser(callback = () => { }, fallback = () => { }) {
    if (KeyExists(tokenKey)) {
        try {
            Token = (decodeText(getKeyValue(tokenKey)))
            UserId = parseInt(decodeText(getKeyValue(userIdKey)))
            IsTokenValid(Token, () => {
                getUser(UserId, Token, callback)
            })
            return
        } catch (error) {
            console.info(`Error parsing token and userId: ${error}`)
            popUpBox('fail', `Error parsing token and userId:: ${error} `, 'catAlert')
            return
        }
    }
    fallback()
}

const checkEmail = (email, callback = () => { }) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/User/CheckEmailExistence?email=${email}`,
        error: (error) => {
            console.log(error)
        },
        success: (message) => {
            if (message.success == true) {
                popUpBox('alert', 'This email exists already!', 'catAlert')
                return
            }
            //console.log(message)
            callback()
        }
    })
}

const AuthenticateUser = (userCredential, callback = () => { }) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Authenticate`,
        data: `{
			"email": "${userCredential.email}",
			"password": "${userCredential.password}",
			"rememberMe": ${userCredential.rememberMe},
			"code": "${userCredential.code}"
		}`,
        dataType: "json",
        contentType: "application/json",
        success: (response) => {
            //console.log(response)
            if (response.success == true) {
                let data = JSON.parse(response.message)
                UserId = parseInt(data.UserId);
                Token = data.Token;
                getUser(data.UserId, data.Token)
                //console.log(userCredential.password)
                setKeyValue(userIdKey, encodeText(`${UserId}`))
                setKeyValue(tokenKey, encodeText(Token))
                setKeyValue(userPassKey, encodeText(userCredential.password))
                callback()
                chAuth()
                //DotNet.invokeMethodAsync(skillit_UI_name, "MarkAsAuthorized", Token).then(result => {
                //    callback(result)
                //})
                return
            }
            loader.addClass('hidden')
            popUpBox('alert', 'Please check your credentials. Response: ' + response.message, 'catAlert')
        }
    }).done((e) => {
        chAuth()
    })
}

const addUser = (user, image, callback = () => { }, fallback = () => { }) => {
    //let formData = new FormData()
    //formData.append('image', image)
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/User/AddUser`,//?userJson=${JSON.stringify(user)}`,
        data: JSON.stringify(user),
        dataType: 'json',
        contentType: 'application/json',
        error: function (error) {
            console.log(error.responseText)
            fallback()
            popUpBox('error', `Failed: ${error.responseText}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                console.log(responseModel)
                callback()
                return
            }
            if (responseModel.message.includes("api.sendgrid.com: 443")) {

                console.log(responseModel)
                callback()
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const updateProfilePicture = (userId, image, token) => {
    let formData = new FormData()
    formData.append('image', image)
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/User/UpdateProfilePicture?userId=${userId}`,
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: function (error) {
            console.log(error.responseText)
            popUpBox('error', `Failed: ${error.responseText}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUser(UserId, Token, () => {
                    loadDash()
                })
                loader.addClass('hidden')
                popUpBox('notify', `Message: Change was successful`, 'catAlert')
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const updateUser = (userId, user, token) => {
    // Convert JavaScript User object to C# UserModel format with proper property names and types
    const userModel = {
        UserId: user.userId,
        Gender: user.gender ? String(user.gender) : "", // Ensure gender is a string
        FirstName: user.firstName,
        LastName: user.lastName,
        Email: user.email,
        Username: user.username,
        Password: user.password,
        Dob: user.dateOfBirth,
        Address: user.address,
        DateCreated: user.dateCreated,
        Phone: user.phone,
        ProfileImage: user.profileImage,
        LoginInfos: user.loginInfos,
        LoginAttemps: user.loginAttemps
    };
    
    $.ajax({
        type: 'put',
        url: `${BaseURL}api/User/UpdateUser`,
        data: JSON.stringify(userModel),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: function (error) {
            console.log(error.responseText)
            popUpBox('error', `Failed: ${error.responseText}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUser(UserId, Token, () => {
                    loadDash()
                })
                loader.addClass('hidden')
                popUpBox('notify', `Message: Change was successful`, 'catAlert')
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const logout = () => {
    UserId = 0;
    Token = '';
    _user = new User()
    deleteKey(userIdKey)
    deleteKey(tokenKey)
    deleteKey(userPassKey)
    //_ROUTER.navigate('/home');
    chAuth()
    location.href = location.origin
}

const getUser = (userId, token, callback = () => { }) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/User/GetUser?id=${userId}`,
        data: '',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (user) => {
            _user = user
            _user.dateOfBirth = new Date(_user.dateOfBirth)
            //console.log(user)
            getAccount(userId, token)
        }
    }).done(() => {
        let initCPage = location.pathname
        if (initCPage.includes('catalogs'))
            loader.addClass('hidden')
        callback()
        //loadDash();
    })
}

function clearInnerHtml(classname) {
    $(`.${classname}`).html('')
}

function loadCourseList(courses) {
    courses.forEach(course => {
        $('.in-progess-list').html('')
        $('.in-progess-list').append(inprogress_course_template(course))

        makeGrid()
        $(`#cip_${course.courseId}`).off('click')
        $(`#cip_${course.courseId}`).click((e) => {
            $('.e-view-box').remove()
            $('.dash-body').append(cip_item_template(course))
            $('.e-view-box').fadeIn(200, () => {
                //$('.e-view-box').css('display', 'flex')
                /*$(`#diseng_${element.engagementId}`).off('click')
                $(`#diseng_${element.engagementId}`).click((event) => {
                    //loader.removeClass('hidden')
                    disengageUser(element)
                    remove_eng_item_template(e.target.closest('.list-item'))
                    remove_engagement_view_box()
                })*/
                $('.e-view-box').get(0).style.top = e.pageY + ($(`#cip_${course.courseId}`).get(0).offsetHeight - (e.pageY - $(`#eng_${course.courseId}`).get(0).offsetTop)) + 'px'
                if (innerWidth <= parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) * 2) {
                    $('.e-view-box').get(0).style.left = (innerWidth / 2 - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
                    return
                }
                $('.e-view-box').get(0).style.left = (e.pageX - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
            })
        })
    });
}

function addToCourseInProgressList(course, link) {
    //console.log(course)
    //$('.in-progess-list').html('')
    $('.in-progess-list').append(inprogress_course_template(course))

    makeGrid('in-progess-list')
    $(`#cip_${course.courseId}`).off('click')
    $(`#cip_${course.courseId}`).click((e) => {
        $('.e-view-box').remove()
        $('.dash-body').append(cip_item_template(course, link))
        $('.e-view-box').fadeIn(200, () => {
            //$('.e-view-box').css('display', 'flex')
            /*$(`#diseng_${element.engagementId}`).off('click')
            $(`#diseng_${element.engagementId}`).click((event) => {
                //loader.removeClass('hidden')
                disengageUser(element)
                remove_eng_item_template(e.target.closest('.list-item'))
                remove_engagement_view_box()
            })*/
            $('.e-view-box').get(0).style.top = e.pageY + ($(`#cip_${course.courseId}`).get(0).offsetHeight - (e.pageY - $(`#cip_${course.courseId}`).get(0).offsetTop)) + 'px'
            if (innerWidth <= parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) * 2) {
                $('.e-view-box').get(0).style.left = (innerWidth / 2 - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
                return
            }
            $('.e-view-box').get(0).style.left = (e.pageX - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
        })
    })
}

function addToCompletedCourseList(course, link) {
    //console.log(course)
    //$('.in-progess-list').html('')
    $('.completed-list').append(completed_course_template(course))

    makeGrid('completed-list')
    $(`#cc_${course.courseId}`).off('click')
    $(`#cc_${course.courseId}`).click((e) => {
        $('.e-view-box').remove()
        $('.dash-body').append(cc_item_template(course, link))
        $('.e-view-box').fadeIn(200, () => {
            //$('.e-view-box').css('display', 'flex')
            /*$(`#diseng_${element.engagementId}`).off('click')
            $(`#diseng_${element.engagementId}`).click((event) => {
                //loader.removeClass('hidden')
                disengageUser(element)
                remove_eng_item_template(e.target.closest('.list-item'))
                remove_engagement_view_box()
            })*/
            $('.e-view-box').get(0).style.top = e.pageY + ($(`#cc_${course.courseId}`).get(0).offsetHeight - (e.pageY - $(`#cc_${course.courseId}`).get(0).offsetTop)) + 'px'
            if (innerWidth <= parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) * 2) {
                $('.e-view-box').get(0).style.left = (innerWidth / 2 - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
                return
            }
            $('.e-view-box').get(0).style.left = (e.pageX - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
        })
    })
}

function loadDash() {
    $('.u-name').text(_user.firstName + " " + _user.lastName)
    $('.dash-greetings').text("Welcome back " + _user.firstName)
    $('.u-email').text(_user.email)
    $('.u-phone').text(_user.phone)
    $('.u-phone').attr('href', `tel:${_user.phone}`)
    $('.u-dob').text(formatDate(_user.dateOfBirth))
    $('.u-g').text(_user.gender == 0 ? "Male" : "Female")
    $('.u-address').text(_user.address)
    if (_user.profileImage.length != 0)
        $('.u-img').attr('src', 'site_data/user_profile_pictures/' + _user.profileImage + "_thumbnail.png")

    getCatalogCaptions(Token, () => {
        getEngagements(UserId, Token, (data) => {
            //try {
            $('.engaged-list').html('')
            data.forEach(element => {
                for (let i = 0; i < CatalogCaptions.length; i++) {
                    if (element.catalogId == CatalogCaptions[i].item1) {
                        $('.engaged-list').append(progress_template(element, CatalogCaptions[i].item2))

                        makeGrid('engaged-list')
                        $(`#eng_${element.engagementId}`).off('click')
                        $(`#eng_${element.engagementId}`).click((e) => {
                            $('.e-view-box').remove()
                            $('.dash-body').append(eng_item_template(element, CatalogCaptions[i].item2))
                            $('.e-view-box').fadeIn(200, () => {
                                //$('.e-view-box').css('display', 'flex')
                                $(`#diseng_${element.engagementId}`).off('click')
                                $(`#diseng_${element.engagementId}`).click((event) => {
                                    //loader.removeClass('hidden')
                                    disengageUser(element)
                                    remove_eng_item_template(e.target.closest('.list-item'))
                                    remove_engagement_view_box()
                                })
                                $('.e-view-box').get(0).style.top = e.pageY + ($(`#eng_${element.engagementId}`).get(0).offsetHeight - (e.pageY - $(`#eng_${element.engagementId}`).get(0).offsetTop)) + 'px'
                                if (innerWidth <= parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) * 2) {
                                    $('.e-view-box').get(0).style.left = (innerWidth / 2 - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
                                    return
                                }
                                $('.e-view-box').get(0).style.left = (e.pageX - parseInt(getComputedStyle($('.e-view-box').get(0)).width.replace('px', '')) / 2) + 'px'
                            })
                        })
                    }
                }
            });
            /* } catch (error) {
                
            } */
        })
    })
    getUserSkill(UserId, Token)
    getUserSocial(UserId, Token)
    $('.dash-greetings').fadeIn(100)
}

function stickyHeader() {
    var header = $('header')
    header.unbind('scroll')
    g_header_height = parseInt(getComputedStyle(document.querySelector('header')).height.replace('px', ''))
    //g_list_height = parseInt(getComputedStyle(document.querySelector('.thumb-list')).height.replace('px', ''))
    let headerOffset = header.offset().top
    $(document).scroll((event) => {
        if (header.offset().top < scrollY) {
            //header.next().next()[0].style.position = 'relative'
            //header.next().next()[0].style.top = g_header_height + 2 + 'px'
            header.css('position', 'fixed')
        } else
            if (scrollY == headerOffset) {
                header.css('position', 'static')
                header.next().next()[0].style.top = ''
            }
    })
}
function calc_height(h, l) {
    return (window.innerHeight - (h + l))
}

const getAccount = (userId, token) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Account/GetAccount?userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            console.log(error)
        },
        success: (detail) => {
            _Detail = detail
            //console.log(detail)
        }
    })
}

const getCatalogs = (token, callback = () => { }) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/Catalog/GetAllCatalogs`,
        /* beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        }, */
        success: (catalogs) => {
            Catalogs = catalogs
            //console.log(catalogs)
        }
    }).done(() => {
        callback(cat_template)
        setEventHandlers()
        chAuth()
        loader.addClass('hidden')
    })
}

const getCatalogCaptions = (token, callback = () => { }) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/Catalog/captions`,
        /* beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        }, */
        success: (captions) => {
            CatalogCaptions = captions
            //console.log(captions)
            callback()
        }
    }).done(() => {
        /* callback(cat_template)
        setEventHandlers()
        chAuth()
        loader.addClass('hidden') */
    })
}

const getCatalog = (catalogId, token) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Catalog/GetCatalog?id=${catalogId}`,
        success: (cat) => {
            catalog = cat
        }
    })
}

function addCatalogRequest(catalog) {
    loader.removeClass('hidden')
    //let catalog = new Catalog($('#catCaption').val(), $('#catDesc').val(), '', '', $('#catLink').val())
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

}

const addCatalog = (catalog, image, token = '') => {
    let formData = new FormData()
    formData.append('image', image);
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Catalog/AddCatalog?catalogJson=${JSON.stringify(catalog)}`,
        data: formData,
        /* dataType: "json",
        contentType: "application/json", */
        contentType: false, //'multipart/form-data',
        processData: false,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: function (error) {
            console.error(error.responseText)
            popUpBox('notify', `Failed: ${error.responseText} `, 'catAlert')
            loader.addClass('hidden')
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getCatalogs(Token)
                //loadCatalog()
                function cb() {
                    location.reload()
                }
                console.log(responseModel.message)
                popUpBox('done', 'Success: Catalog successfully added.', "cat_add_message_btn", "", cb)
                return
            }
            loader.addClass('hidden')
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const updateCatalog = (catalog, image, token) => {
    let formData = new FormData()
    formData.append('image', image);
    catalog.image = ''
    $.ajax({
        type: 'put',
        url: `${BaseURL}api/Catalog/UpdateCatalog?catalogJson=${JSON.stringify(catalog)}`,
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getCatalogs(Token)
                loadCatalog()
                //console.log(responseModel.message)
                popUpBox('done', 'Success: Catalog successfully updated.')
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const engageRequest = (engagement, token, callback = () => { }) => {
    //console.log(engagement)
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/Engagement/add`,
        data: JSON.stringify(engagement),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            loader.addClass('hidden')
            popUpBox('error', `Failed: ${error.responseText} `, 'catAlert')
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                callback()
                return
            }
            loader.addClass('hidden')
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

function makeGrid(name) {
    var el = $(`.${name}.list`).get(0)
    if (el.childElementCount <= 0) {
        el.classList.remove('list-grid')
        return
    }
    el.classList.add('list-grid')
}

const getEngagements = (userId, token, callback = () => { }) => {
    //console.log(userId)
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/Engagement/get?userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            loader.addClass('hidden')
            //popUpBox('error', `Failed: ${error.responseText} `, 'catAlert')
        },
        success: (data) => {
            Engagements = data
            getEngagementslist(userId, token)
            callback(data)
        }
    })
}

const getEngagementslist = (userId, token) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/Engagement/getList?userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            console.log(error.responseText)
        },
        success: (data) => {
            EngagementsUserIdList = data.join(', ')
        }
    })
}

const getEngagementUserCatalogIdList = (catalogId, userId, token, callback = () => { }) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/Engagement/getUserCatalogIdList?catalogId=${catalogId}&userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            console.log(error.responseText)
        },
        success: (data) => {
            EngagementUserCatalogIdList = data.join(', ')
            callback()
        }
    })
}

const disengageRequest = (engagement, token, callback = () => { }) => {
    $.ajax({
        type: 'delete',
        url: `${BaseURL}api/Engagement/remove`,
        data: JSON.stringify(engagement),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            loader.addClass('hidden')
            popUpBox('error', `Failed: ${error.responseText} `, 'catAlert')
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                callback(responseModel)
                return
            }
            loader.addClass('hidden')
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const getUserSkills = (token) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/UserSkill/GetUserSkills`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (skills) => {
            //console.log(skills)
        }
    })
}

const getUserSkill = (userId, token) => {
    $.ajax({
        type: "post",
        url: `${BaseURL}api/UserSkill/GetUserSkillForUser?userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader("Authorization", `Bearer ${token}`);
        },
        success: (skills) => {
            userSkills = skills;
        },
    }).done(() => {
        loadSkills()
        $('.sk-del').click((e) => {
            let id = e.target.parentElement.id.substring(6) || e.target.id.substring(6);
            deleteUserSkill(id, Token)
            $(e.target.closest('.skill')).remove()
        })

        setEventHandlers()
        //loader.addClass('hidden')
    })
}

const addUserSkills = (userSkill, token) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/UserSkill/AddUserSkills`,
        data: JSON.stringify(userSkill),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUserSkill(UserId, Token)
                //console.log(responseModel.message)
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const updateUserSkill = (id, userSkill, token) => {
    $.ajax({
        type: 'put',
        url: `${BaseURL}api/UserSkill/UpdateUserSkill/${id}`,
        data: JSON.stringify(userSkill),
        dataType: 'json',
        contentType: 'application/json',
        error: (error) => {
            console.log(error)
        },
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUserSkill(UserId, Token)
                console.log(responseModel.message)
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const deleteUserSkill = (id, token) => {
    $.ajax({
        type: 'delete',
        url: `${BaseURL}api/UserSkill/DeleteUserSkill/${id}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => {
            console.log(error)
            popUpBox('notify', `Failed: ${error} `, 'catAlert')
        },
        success: (responseModel) => {
            getUserSkill(UserId, Token)
        }
    })
}

const getUserSocials = (token) => {
    $.ajax({
        type: 'get',
        url: `${BaseURL}api/UserSocial/GetUserSocials`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (socials) => {
            //console.log(socials)
        }
    })
}

const getUserSocial = (userId, token) => {
    $.ajax({
        type: "post",
        url: `${BaseURL}api/UserSocial/GetUserSocialForUser?userId=${userId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader("Authorization", `Bearer ${token}`);
        },
        success: (socials) => {
            userSocials = socials;
        },
    }).done(() => {
        loadSocials()

        $('.sc-del').click((e) => {
            let id = e.target.id.substring(6) || e.target.parentElement.id.substring(6);
            deleteUserSocial(id, Token)
            $(e.target.closest('.social')).remove()
        })
    })
}

const addUserSocial = (userSocial, token) => {
    $.ajax({
        type: 'post',
        url: `${BaseURL}api/UserSocial/AddUserSocial`,
        data: JSON.stringify(userSocial),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUserSocial(UserId, Token)
                //console.log(responseModel.message)
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const updateUserSocial = (id, userSocial, token) => {
    $.ajax({
        type: 'put',
        url: `${BaseURL}api/UserSocial/UpdateUserSocial/${id}`,
        data: JSON.stringify(userSocial),
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUserSocial(UserId, Token)
                console.log(responseModel.message)
                return
            }
            popUpBox('notify', `Failed: ${responseModel.message} `, 'catAlert')
        }
    })
}

const deleteUserSocial = (id, token) => {
    $.ajax({
        type: 'delete',
        url: `${BaseURL}api/UserSocial/DeleteUserSocial/${id}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`)
        },
        error: (error) => { console.log(error) },
        success: (responseModel) => {
            if (responseModel.success == true) {
                getUserSocial(UserId, Token)
            }
            popUpBox('notify', `Message: ${responseModel.message} `, 'catAlert')
        }
    })
}

async function getAccountNotifications(accountId, token, callback) {
    if (token == '' || !token) return
    if (!accountId || accountId === 'undefined' || accountId === undefined) return
    let request = $.ajax({
        type: "get",
        url: `${BaseURL}api/account/notifications/getAccountNotifications?accountId=${accountId}`,
        beforeSend: (xhr) => {
            xhr.setRequestHeader("Authorization", `Bearer ${token}`)
        },
        error: (error) => {
            console.log("Error on getting notifications. Details:", error)
        },
        success: (notifications) => {
            //console.log(notifications)
        },
    })

    return request
}
