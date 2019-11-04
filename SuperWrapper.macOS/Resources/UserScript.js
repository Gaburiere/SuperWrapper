/**
 * Incomplete Notification API override to enable native notifications.
 */
class NotificationOverride {
    // Grant permission by default to keep this example simple.
    // Safari 13 does not support class fields yet, so a static getter must be used.
    static get permission() {
        alert("GET PERMISSION");
        return "granted";
    }

    // Safari 13 still uses callbacks instead of promises.
    static requestPermission (callback) {
        alert("REQUEST PERMISSION");
        callback("granted");
    }

    // Forward the notifiation text to the native app through the script message handler.
    constructor (messageText) {
        alert("CTOR");
        window.webkit.messageHandlers.notify.postMessage(messageText);
    }
}

// Override the global browser notification object.
window.Notification = NotificationOverride;