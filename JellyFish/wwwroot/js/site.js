﻿$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover({
        placement: 'bottom',
        content: function () {
            return $("#notification-content").html();
        },
        html: true
    });

    $('body').append(`<div id="notification-content" class="hide"></div>`)


    function getNotification() {
        var res = "<ul class='list-group'>";
        $.ajax({
            url: "/Notification/GetNotification",
            method: "GET",
            success: function (result) {
                $("#notificationCount").html(result.count);
                if (result.count != 0) {
                    $("#notificationCount").html(result.count);
                    $("#notificationCount").show('slow');
                } else {
                    $("#notificationCount").html();
                    $("#notificationCount").hide('slow');
                    $("#notificationCount").popover('hide');
                }

                var notifications = result.userNotification;
                notifications.forEach(element => {
                    res = res + "<li  class='list-group-item notification-text' id='"+element.notificationId+"'>" + element.notifications.text + "</li>";
                });

                res = res + "</ul>";
                //console.log(res);



                $("#notification-content").html(res);

                //console.log(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    

    $("ul").on('click', 'li.notification-text', function (e) {
        var target = e.target;
        var id = $(target).data('id');
        console.log(id);
        readNotification(id, target);
    })


    function readNotification(id, target) {
        $.ajax({
            url: "/Notification/ReadNotification",
            method: "GET",
            data: { notificationId: id },
            success: function (result) {
                getNotification();
                $(target).fadeOut('slow');
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

    getNotification();

    //let connection = new signalR.HubConnection("/signalServer");

    //connection.on('displayNotification', () => {
    //    getNotification();
    //});

    //connection.start();

});
