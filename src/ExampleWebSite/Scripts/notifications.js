(function () {
    var initialize = function (url) {
        var connection = $.hubConnection(url, '', false, { xdomain: true }),
            notificationHub = connection.createHubProxy('notificationHub');

        notificationHub.on('showMessage', function (message, title, type, url) {
            var options = {};

            if (url) {
                options.onclick = function () {
                    location.href = url;
                };
            }

            toastr[type](message, title, options);
        });

        connection.start();
    };

    window.notifications = {
        listen: initialize
    };
})();