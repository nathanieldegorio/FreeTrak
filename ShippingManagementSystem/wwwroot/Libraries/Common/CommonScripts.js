function Common() {
}

Common.serviceRequest = function (url, data, success_function, defDataType) {
    if (defDataType == undefined || defDataType == null)
    {
        defDataType = "json";
    }
    $.ajax({
        type: "POST",
        url: "/api/"+url,
        data: data,
        success: success_function,
        dataType: defDataType
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
    if (certkey == "" || certkey == undefined)
    {
        Common.deleteAllCookies();
        return "";
    } else
    {
        var cook = Cookies.get(certkey);
        if (cook == undefined || cook == "")
        {
            return "";
        }
        var userDetails = JSON.parse(Cookies.get(certkey));
        if (certkey == "" || userDetails == undefined) {

            return "";
        } else {
            return userDetails[propertyKey];
        }

    }
   
}



Common.setLoginDetails = function (properties)
{
    var certkey = Common.getCertificate();
    Cookies.set(certkey, properties, { expires: 7 });
}

Common.setCertificate = function (certificateKey)
{
    Cookies.set('FTSecCertificate', certificateKey, { expires: 365 });
}

Common.custAlert = function (header, Message, yesText,yesFunction, noText, noFunction, params)
{
    $('#alertModal .modal.content').html(Message);
    $('#alertModal .modal.header').html(header);
    if (yesText == undefined || yesText == '')
    {
        $('#alertModal .actions .ui.red.basic.cancel.button').show();
     
    } else
    {
        $('#alertModal .actions .ui.green.ok.button').html(yesText);
        $('#alertModal .actions .ui.red.basic.cancel.button').show();
        $('#alertModal .actions .ui.red.basic.cancel.button').html(noText);

        $('#alertModal .actions .ui.green.ok.button').on('click', yesFunction(params));
        $('#alertModal .actions .ui.red.basic.cancel.button').on('click', noFunction(params));


    }
    $('#alertModal').modal('show');


}

Common.loopToTemplate = function (data, template, loadToElement)
{
    finalHtml = "";
    $(loadToElement).html("");
    data.forEach(function (vv, iv) {
        createTemp = template;
        finalHtml = finalHtml + createTemp;
        
        for (var key in vv)
        {
            if (vv.hasOwnProperty(key)) {
                finalHtml = finalHtml.replace("{{" + key + "}}", vv[key]);
            }
        }
      
       
    });
   
    $(loadToElement).html(finalHtml);
}

Common.loadToTemplate = function (data, template, loadToElement, callback)
{
        finalHtml = template;
        for (var key in data)
        {
            $(loadToElement).find("#"+key).val(data[key]);
        }
        callback();
 }

Common.deleteAllCookies = function() {
    var cookies = document.cookie.split(";");

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var eqPos = cookie.indexOf("=");
        var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}