var denstityOf22Kt = 17.3;
var denstityOf18Kt = 15;
var denstityOf14Kt = 13;

$(document).ready(function () {
    debugger;

    $('#txtMaxWeight').on('input', function () {
        CalculateExtimatedWeight();
        CalculateGrossWeight();
        CalculateNetWeight();
    });
    $('.findings').on('input', function () {
        CalculateTotalAmountByName('findings', 'txtTotalFindingWeight');
        CalculateExtimatedWeight();
        CalculateGrossWeight();
        CalculateNetWeight();
    });
    
    $('.stoneWt').on('input', function () {
        CalculateTotalAmountByName('stoneWeight', 'txtTotalStoneWt');
        CalculateGrossWeight();
    });

    $('.stoneDisc').on('input', function () {
        CalculateTotalAmountByName('stoneDiscount', 'txtTotalStoneDiscount');
        CalculateNetWeight();
    });
})

function CalculateExtimatedWeight() {

    var waxWeight = $('#txtMaxWeight').val();
    var totalFindingWeight = $('#txtTotalFindingWeight').val();

    if ($.isNumeric(waxWeight)) {

        var extimatedWt14Kt = parseFloat(totalFindingWeight) + (parseFloat(waxWeight) * parseFloat(denstityOf14Kt));
        var extimatedWt18Kt = parseFloat(totalFindingWeight) + (parseFloat(waxWeight) * parseFloat(denstityOf18Kt));
        var extimatedWt22Kt = parseFloat(totalFindingWeight) + (parseFloat(waxWeight) * parseFloat(denstityOf22Kt));

        $('#txt14KtExtimatedWeight').val(extimatedWt14Kt);
        $('#txt18KtExtimatedWeight').val(extimatedWt18Kt);
        $('#txt22KtExtimatedWeight').val(extimatedWt22Kt);

    }
    else {
        $('#txt14KtExtimatedWeight').val('0.00');
        $('#txt18KtExtimatedWeight').val('0.00');
        $('#txt22KtExtimatedWeight').val('0.00');
    }
}

function CalculateGrossWeight() {
    debugger;
    var extimatedWt14Kt = $('#txt14KtExtimatedWeight').val();
    var extimatedWt18Kt = $('#txt18KtExtimatedWeight').val();
    var extimatedWt22Kt = $('#txt22KtExtimatedWeight').val();

    var totalStoneWt = $('#txtTotalStoneWt').val();

    if ($.isNumeric(totalStoneWt)) {
        var grossWt14Kt = parseFloat(extimatedWt14Kt) + parseFloat(totalStoneWt);
        var grossWt18Kt = parseFloat(extimatedWt18Kt) + parseFloat(totalStoneWt);
        var grossWt22Kt = parseFloat(extimatedWt22Kt) + parseFloat(totalStoneWt);

        $('#txtGrossWt14Kt').val(grossWt14Kt);
        $('#txtGrossWt18Kt').val(grossWt18Kt);
        $('#txtGrossWt22Kt').val(grossWt22Kt);
    }
    else {
        $('#txtGrossWt14Kt').val('0.00');
        $('#txtGrossWt18Kt').val('0.00');
        $('#txtGrossWt22Kt').val('0.00');
    }
}

function CalculateNetWeight() {

    debugger;
    var totalStoneDiscount = $('#txtTotalStoneDiscount').val();
    if ($.isNumeric(totalStoneDiscount)) {

        var grossWt14Kt = parseFloat($('#txtGrossWt14Kt').val());// extimatedWt14Kt + totalStoneWt;
        var grossWt18Kt = parseFloat($('#txtGrossWt18Kt').val());//extimatedWt18Kt + totalStoneWt;
        var grossWt22Kt = parseFloat($('#txtGrossWt22Kt').val());//extimatedWt22Kt + totalStoneWt;

        if (grossWt14Kt > 0) {
            $('#txtNetWt14Kt').val(grossWt14Kt - parseFloat(totalStoneDiscount));
        }
        if (grossWt14Kt > 0) {
            $('#txtNetWt18Kt').val(grossWt18Kt - parseFloat(totalStoneDiscount));
        }
        if (grossWt14Kt > 0) {
            $('#txtNetWt22Kt').val(grossWt22Kt - parseFloat(totalStoneDiscount));
        }
    }
    else {
        $('#txtNetWt14Kt').val($('#txtGrossWt14Kt').val());
        $('#txtNetWt18Kt').val($('#txtGrossWt18Kt').val());
        $('#txtNetWt22Kt').val($('#txtGrossWt22Kt').val());
    }
}





function getSubCategory() {
    var categoryId= $('#selectCategory').val();
    if (categoryId > 0) {

        $.ajax({
            url: '/Product/GetSubCategory',
            type: 'Get',
            data: { productCategoryId: categoryId },
            contentType: 'application/json',
            success: function (data) {
                if (data != undefined) {
                    debugger;
                    $('#subcategorySection').show();
                    $('#subcategorySection').html(data.html)
                    // set vlaues
                }
            },
            error: function (a, ax, adx) {
                $('#subcategorySection').hide();
            }
        });
    }
    else
    {
        $('#subcategorySection').hide();
    }
}


// read all values from stone textbox, 
// fetch value, 
// and do some , and assigne it to total box, 

function CalculateTotalAmountByName(elementName, totalElementId) {
    debugger;   
    var totalStoneWeight = 0.00;
    debugger;
    $('[name="'+elementName+'"]').each(function () {
        var amount = $(this).val();
        if ($.isNumeric(amount)) {
            totalStoneWeight +=parseFloat(amount);
        }
    });
    $('#'+totalElementId).val(totalStoneWeight);
}


