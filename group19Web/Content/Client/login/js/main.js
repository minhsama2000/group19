$(function() {
	'use strict';

	
  $('.form-control').on('input', function() {
	  var $field = $(this).closest('.form-group');
	  if (this.value) {
	    $field.addClass('field--not-empty');
	  } else {
	    $field.removeClass('field--not-empty');
	  }
	});

});

function validateRegister() {
    var email = document.getElementById("email");
    var username = document.getElementById("username");
    var password = document.getElementById("password");
    var phone = document.getElementById("phone");
    var address = document.getElementById("address");
    var fullname = document.getElementById("fullname");
    var passwordAgain = document.getElementById("againPassword");
    var filter =
        /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var filter1 = /^([a-zA-Z0-9_\.\-])/;
    var filter3 = /^([a-zA-Z_\.\-])/;
    var filter2 = /^([0-9_\.\-])/;
    if (!filter3.test(fullname.value)) {
        alert("Hay nhap so ten hop le.\n Example: Nguyễn Văn A");
        email.focus;
        return false;
    }
    if (!filter2.test(phone.value)) {
        alert("Hay nhap so dien thoai hop le.\n Example: 0962177082");
        email.focus;
        return false;
    }
    if (!filter.test(email.value)) {
        alert("Hay nhap dia chi email hop le.\nExample@gmail.com");
        email.focus;
        return false;
    }
    if (!filter1.test(username.value)) {
        alert("hay nhap ten hop le \n Example: minhsama2000");
        username.focus;
        return false;
    }
    if (!filter1.test(password.value)) {
        alert("hay nhap password hop le");
        password.focus;
        return false;
    }
    if (!(password.value === passwordAgain.value)) {
        console.log(password.value);
        console.log(passwordAgain.value);
        alert("password không đúng");
        password.focus;
        return false;
    }
    return true;
}

function validateLogin() {
    var username = document.getElementById("username");
    var password = document.getElementById("password");
    var filter =
        /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var filter1 = /^([a-zA-Z0-9_\.\-])/;
    if (!filter1.test(username.value)) {
        alert("hay nhap ten hop le minhsama2000");
        username.focus;
        return false;
    }
    if (!filter1.test(password.value)) {
        alert("hay nhap password hop le minhsama2000");
        password.focus;
        return false;
    }
    return true;
}

function validateFormPayment() {
    var fullname = document.getElementById("fullname");
    var phone = document.getElementById("phone");
    var email = document.getElementById("email");
    var address = document.getElementById("address");
    var filter =
        /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var filter1 = /^([a-zA-Z0-9_\.\-])/;
    var filter2 = /^([0-9_\.\-])/;
    if (!filter.test(email.value)) {
        alert("hay nhap email hop le \n example: minhsama@gmail.com");
        email.focus;
        return false;
    }
    if (!filter1.test(fullname.value)) {
        alert("hay nhap ten hop le \n example: Nguyễn Văn A");
        fullname.focus;
        return false;
    }
    if (!filter2.test(phone.value)) {
        alert("hay nhap so dien thoai hop le \n example: 0962177082");
        phone.focus;
        return false;
    }
    return true;
}

function validateUpdateUser() {
    var email = document.getElementById("email");
    var phone = document.getElementById("phone");
    var fullname = document.getElementById("fullname");
    var filter =
        /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    var filter1 = /^([a-zA-Z0-9_\.\-])/;
    var filter2 = /^([a-zA-Z\.\-])/;
    var filter3 = /^([0-9_\.\-])/;
    if (!filter2.test(fullname.value)) {
        alert("Hay nhap so ten hop le.\n Example: Nguyễn Văn A");
        email.focus;
        return false;
    }
    if (!filter3.test(phone.value)) {
        alert("Hay nhap so dien thoai hop le.\n Example: 0962177082");
        email.focus;
        return false;
    }
    if (!filter.test(email.value)) {
        alert("Hay nhap dia chi email hop le.\nExample@gmail.com");
        email.focus;
        return false;
    }
    return true;
}