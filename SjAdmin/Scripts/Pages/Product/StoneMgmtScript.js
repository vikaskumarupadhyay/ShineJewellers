function editStone(stoneId) {
    $.ajax({
        url: '/Product/GetStoneDetail',
        type: 'Get',
        data: { stoneId: stoneId },
        contentType: 'application/json',
        success: function (data) {
            if (data != undefined) {
                $('#hdnStoneID').val(data.StoneId);
                $('#txtStoneName').val(data.StoneName);
                $('.ui.modal').modal('show');
            }
        },
        error: function (a, ax, adx) {
            $('#hdnFindingID').val('0');
        }
    });

}
function displayStoneCreatePopup() {

    $('#hdnStoneID').val('0');
    $('.ui.modal').modal('show');
}
function deleteStone(stoneId) {
    if (confirm('Are you sure, you want to delete it')) {
        $.ajax({
            url: '/Product/DeleteStone',
            type: 'POST',
            data: { stoneId: stoneId },
            success: function (data) {
                alert(data.DeleteMessage);
                window.location.href = "/Product/DisplayAllStone";
            },
            error: function (x, ex, dx) {

            }

        });
    }

}

function saveStone() {

    var stoneId = $('#hdnStoneID').val();

    // create finding Object
    var stoneItem =
        {
            StoneId: stoneId,
            StoneName: $('#txtStoneName').val(),
            IsActive: 1
        };
    // pass it to server, via ajax call
    $(window).showWaitScreen(function () {
        $.ajax({
            url: '/Product/SaveStone',
            data: JSON.stringify(stoneItem),
            type: 'POST',
            contentType: 'application/json',
            success: function (data) {
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

