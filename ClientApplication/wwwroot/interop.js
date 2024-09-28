async function getBrowserInfo()
{
    var browser = getBrowserName(navigator.userAgent);
    let result = {
        browserName: browser,
        os: navigator.platform,
        time: new Date().toLocaleString()
    };
    if (navigator.geolocation) {
        try {
            const position = await getCurrentPosition();
            result.latitude = position.coords.latitude;
            result.longitude = position.coords.longitude;
        } catch (error) {
            if (error.code === error.PERMISSION_DENIED) {
                console.error('User denied geolocation permission.');                
            } else {
                console.error('Error getting geolocation:', error.message);
            }
            result.latitude = null;
            result.longitude = null;
        }
    } else {
        result.latitude = null;
        result.longitude = null;
    }
    return result;
}
function getBrowserName(userAgent)
{
    var browserName = "Unknown";
    if (userAgent != null) {
        if (userAgent.match(/(Edge|Edg)/)) {
            browserName = "Microsoft Edge";
        } else if (userAgent.match(/Firefox/)) {
            browserName = "Mozilla Firefox";
        } else if (userAgent.match(/Chrome/)) {
            browserName = "Google Chrome";
        } else if (userAgent.match(/Safari/) && !userAgent.match(/Chrome/)) {
            browserName = "Safari";
        } else if (userAgent.match(/Opera/)) {
            browserName = "Opera";
        } else if (userAgent.match(/Trident/)) {
            browserName = "Internet Explorer";
        }
    }
    return browserName;
}

function getCurrentPosition() {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });
}