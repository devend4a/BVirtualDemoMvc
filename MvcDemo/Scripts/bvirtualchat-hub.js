var initChatHub = function (refreshOnlineUserListCallBack, getChatMessageCallBack) {
    var chat = $.connection.bVirtualChat;
    $.connection.hub.start().done(function () {
        chat.server.getOnlineUserList();
    });

    chat.client.refreshOnlineUserList = function (userList) {
        console.log(userList);
        if (refreshOnlineUserListCallBack) {
            refreshOnlineUserListCallBack(userList);
        }
    }

    chat.client.getChatMessage = function (message, to, from) {
        if (getChatMessageCallBack) {
            getChatMessageCallBack(message, to, from);
        }
    }

    this.sendChatMesage = function (message, to, from) {
        chat.server.sendChatMessage(message, to, from);
    }
}