$(document).ready(function () {

    if (Common.getLoginDetails("userid") == undefined || Common.getLoginDetails("userid") == "")
    {
        defaultLoad();

    } else
    {
        sesssionLoad();
    }
    
});

function defaultLoad()
{
    Common.templateRequest("landing.html", "main");
   
}
function sesssionLoad()
{
    Common.templateRequest("dashboard.html", "main");
}

