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

    $('#txtStyleNo').on('input', function () {
        UpdateProductId();
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

//function GetSubCategories() {
//    var selectedSubCategory = new Array();
//    $('[name="subCategoryCheckbox"]').each(function () {
//        if ($(this).is(":checked")) {
//            selectedSubCategory.push($(this).val());
//        }
//    });
//    return selectedSubCategory;
//}

function GetSubCategories() {
    var selectedSubCategories = '';
    $('[name="subCategoryCheckbox"]').each(function () {
        if ($(this).is(":checked")) {
            selectedSubCategories += $(this).val() + ",";
        }
    });
    selectedSubCategories = selectedSubCategories.substring(0, selectedSubCategories.lastIndexOf(","));
    return selectedSubCategories;
}



function GetStoneWeightAndDiscounts() {
    var stoneWeights = '';
    var stoneIds = "";
    var stoneDiscountValue = "";

    $('[name="stoneWeight"]').each(function () {
        var stoneWeight = $(this).val();
        var stoneId = $(this).attr('data-value');
        stoneWeights = stoneWeights + stoneWeight + ",";
        stoneIds = stoneIds + stoneId + ",";

    });
    stoneWeights = stoneWeights.substring(0, stoneWeights.lastIndexOf(","));
    stoneIds = stoneIds.substring(0, stoneIds.lastIndexOf(","));

    $('[name="stoneDiscount"]').each(function () {
        var stoneDiscount = $(this).val();
        stoneDiscountValue = stoneDiscountValue + stoneDiscount + ",";
    });

    stoneDiscountValue = stoneDiscountValue.substring(0, stoneDiscountValue.lastIndexOf(","));

    var StoneWeightAndDiscounts =
        {
            StoneIds: stoneIds,
            StoneWeight: stoneWeights,
            StoneDiscout: stoneDiscountValue
        };
    return StoneWeightAndDiscounts;
}




//function CreateEmptyStoneAndDiscount() {
//    var StoneAndDiscountPerProduct =
//        {
//            Id: '0',
//            ProductId: '0',
//            StoneId: '0',
//            StoneWeight: '0',
//            StoneDiscount: '0',
//        };
//}
//function GetStoneWeightAndDiscounts() {
//    var stoneAndDiscountPerProductCollection = new Array();
//    $('name=["stoneWeight"]').each(function () {
//        var stoneAndDiscountPerProduct = new StoneAndDiscountPerProduct();

//        stoneAndDiscountPerProduct.ProductId = $('hdnProductId').val();
//        var stoneWeight = $(this).val();

//        debugger;

//        var stoneId = $(this).attr('data-value');
//        stoneAndDiscountPerProduct.StoneId = stoneId;

//        if ($.isNumeric(stoneWeight)) {
//            stoneAndDiscountPerProduct.StoneWeight = stoneWeight;
//        }

//    });
//    return selectedSubCategory;
//}




function GetProduct() {
    var StoneWeightAndDiscounts = GetStoneWeightAndDiscounts();
    var FindingInfoPerProduct = GetFindingDetails();
    var product =
    {
        ProductId: $('#hdnProductId').val(),

        DesignNo: $('#txtDesignNo').val(),
        DyeNo: $('#txtDyeNo').val(),
        StyleNo: $('#txtStyleNo').val(),

        ProductCode: $('#txtProductCode').val(),

        CategoryId: $('#selectCategory').val(),
        SubCategoryId: GetSubCategories(),

        MasterWeight: $('#txtMasterWt').val(),
        WaxWeight: $('#txtMaxWeight').val(),

        DisplayForB2B: $('#chkB2bDisplayOption').is(':checked'),
        DisplayForB2C: $('#chkB2cDisplayOption').is(':checked'),
        DisplayForB2BExclusive: $('#chkB2bExclusiveDisplayOption').is(':checked'),

        ExtimatedWeight_14KT: $('#txt14KtExtimatedWeight').val(),
        ExtimatedWeight_18KT: $('#txt18KtExtimatedWeight').val(),
        ExtimatedWeight_22KT: $('#txt22KtExtimatedWeight').val(),

        GrossWeight_14KT: $('#txtGrossWt14Kt').val(),
        GrossWeight_18KT: $('#txtGrossWt18Kt').val(),
        GrossWeight_22KT: $('#txtGrossWt22Kt').val(),

        NetWeight_14KT: $('#txtNetWt14Kt').val(),
        NetWeight_18KT: $('#txtNetWt18Kt').val(),
        NetWeight_22KT: $('#txtNetWt22Kt').val(),

        StoneIds: (StoneWeightAndDiscounts != null ? StoneWeightAndDiscounts.StoneIds : null),
        StoneWeights: (StoneWeightAndDiscounts != null ? StoneWeightAndDiscounts.StoneWeight : null),
        StoneDiscounts: (StoneWeightAndDiscounts != null ? StoneWeightAndDiscounts.StoneDiscout : null),

        ProductAvailableAs14Kt: $('#chk14KtOption').is(':checked'),
        ProductAvailableAs18Kt: $('#chk18KtOption').is(':checked'),
        ProductAvailableAs22Kt: $('#chk22KtOption').is(':checked'),
        FindingWeights: (FindingInfoPerProduct != null ? FindingInfoPerProduct.FindingWeights : null),
        FindingIds: (FindingInfoPerProduct != null ? FindingInfoPerProduct.FindingIds : null),
    };
    // create new table where we wills store productid and stone id, stoneweight, stonediscount, 

    return product;
}

function SaveProduct() {
    //CreateProduct
    var product = GetProduct();
    $.ajax({
        url: '/Product/CreateProduct',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(product),
        success: function (data) {
            if (data != undefined) {
                displayMessageBoard(data.SaveMessage);
                if (data.IsSuccess) {
                    window.setTimeout(function () {
                        window.location.reload(true);
                    }, 2000);
                    $("html, body").animate({ scrollTop: 0 }, 600);
                    $('#hdnProductId').val('0');
                }
            }
        },
        error: function (x, ax, dss) {

        }
    });
}


function displayMessageBoard(message) {
    if ($('#productMessageBoard').hasClass('hidden')) {
        $('#productMessageBoard').removeClass('hidden');
    }
    $('#productMessageBoard').addClass('visible');
    $('#productMessageBoard').text(message);
}



function hideMessageBoard() {
    if ($('#productMessageBoard').hasClass('visible')) {
        $('#productMessageBoard').removeClass('visible');
    }
    $('#productMessageBoard').addClass('hidden');
    $('#productMessageBoard').text('');
}

function UpdateProductId() {
    debugger;
    var productCode = $('#txtDesignNo').val() + "-" + $('#txtDyeNo').val() + "-" + $('#txtStyleNo').val();
    $('#txtProductCode').val(productCode);
}

function GetFindingDetails() {
    var FindingDetails =
        {
            FindingIds: '',
            FindingWeights: ''
        };

    var findingIds = '';
    var findingWeights = "";


    $('[name="findings"]').each(function () {
        var findingWeight = $(this).val();
        var findingId = $(this).attr('data-value');
        findingWeights = findingWeights + findingWeight + ",";
        findingIds = findingIds + findingId + ",";
    });

    findingWeights = findingWeights.substring(0, findingWeights.lastIndexOf(","));
    findingIds = findingIds.substring(0, findingIds.lastIndexOf(","));

    FindingDetails.FindingIds = findingIds;
    FindingDetails.FindingWeights = findingWeights;

    return FindingDetails;
}



function editProduct(productId) {

}



function deleteProduct(productId) {

}


function createNewProduct()
{
    window.location.href = "/Product/CreateNew";

}