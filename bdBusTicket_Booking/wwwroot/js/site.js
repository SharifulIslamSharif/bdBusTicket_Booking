
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadNotifications", function () {
        LoadNotification();
    });

    LoadNotification();

    function LoadNotification() {
       
        var tr = '';
        $.ajax({
            url: '/Notifications/Notificatons/CheckLogin',
            method: 'GET',
            success: (result) => {
                if (result) {
                    $.ajax({
                        url: '/Notifications/Notificatons/GetNotification',
                        method: 'GET',
                        success: (result) => {
                            //console.log(result);
                            //alert(result.length);
                            $("#notificationNo").text(result.length);
                        },
                        error: (error) => {
                            console.log(error);
                        }
                    })
                } else return false;
            },
            error: (error) => {
                console.log(error);
            }
        })
       
    }

})

