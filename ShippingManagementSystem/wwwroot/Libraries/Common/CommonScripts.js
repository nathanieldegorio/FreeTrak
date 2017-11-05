function Common() {
}

Common.serviceRequest = function(url, data, success_function, dataType)
{
    $.ajax({
        type: "POST",
        url: "/api/"+url,
        data: data,
        success: success_function,
        dataType: "json"
    });
}

Common.templateRequest = function (url, success) {
    $.ajax({
        url: "Views/"+url,
        data: {},
        success: function (data) {
            $('#' + success).html(data);
        },
        dataType: "text"
    });
}

Common.getCertificate = function ()
{
    var cert = Cookies.get('FTSecCertificate');
    if (cert == undefined)
    {
        return "";
    } else
    {
        var certobj = JSON.parse(cert);
        return certobj.userid;

    }
}

Common.getLoginDetails = function (propertyKey)
{
    var certkey = Common.getCertificate();
    var userDetails = JSON.parse(Cookies.get(certkey));
    if (certkey == "" || userDetails == undefined) {
        return "";
    } else {
        return userDetails[propertyKey];
    }
    
}

Common.setLoginDetails = function (properties)
{
    var certkey = Common.getCertificate();
    Cookies.set(certkey, properties, { expires: 365 });
}

Common.setCertificate = function (certificateKey)
{
    Cookies.set('FTSecCertificate', certificateKey, { expires: 7 });
}