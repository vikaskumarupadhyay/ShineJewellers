function editFinding(findingId)
{
    $.ajax({
        url: '/Product/GetFindingDetail',
        type: 'Get',
        data: { findingId: findingId },
        contentType:'application/json',
        success: function (data) {
            if (data != undefined) {
                $('#hdnFindingID').val(data.FindingID);
                $('#txtFindingName').val(data.FindingName);
                $('.ui.modal').modal('show');
            }
        },
        error: function (a,ax,adx)
        {
            $('#hdnFindingID').val('0');
        }
    });
     
}
function displayFindingCreatePopup()
{

    $('#hdnFindingID').val('0');
    $('.ui.modal').modal('show');
}
function resetFindingId() {


}

function saveFinding() {
  
        var findingId = $('#hdnFindingID').val();

        // create finding Object
        var productFinding =
            {
                FindingId: findingId,
                FindingName: $('#txtFindingName').val(),
                IsActive:1
            };
        // pass it to server, via ajax call
      $(window).showWaitScreen(function () 
        {
            $.ajax({
                url: '/Product/SaveFinding',
                data:  JSON.stringify(productFinding) ,
                type: 'POST',
                contentType:'application/json',
                success: function (data)
                {
                    $(window).hideWaitScreen(function () {
                        // display success message and close the popup
                        alert(data.UpdateMessage);
                        window.location.reload(true);
                    });
                    
                },
                error: function (x, d, xd) {
                    $(window).hideWaitScreen();
                }
            });

        });

       

}

