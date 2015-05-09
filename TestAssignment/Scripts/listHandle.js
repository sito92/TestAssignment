$(document).ready(function () {
    $(".action-add").show();
    $(".action-delete").hide();
    $(".action-edit").hide();
});
function ActionListChange(checkedAmmount) {
    if (checkedAmmount<=0) {
        $(".action-add").show();
        $(".action-delete").hide();
        $(".action-edit").hide();
    }
    if (checkedAmmount==1) {
        $(".action-add").hide();
        $(".action-edit").show();
        $(".action-delete").show();
           
    }
    if (checkedAmmount>1) {
        $(".action-add").hide();
        $(".action-edit").hide();
        $(".action-delete").show();
    }
}
function CountCheckedInputs() {
    var checkedIputs = $('#mainform input[type=checkbox]:checked');
    return checkedIputs.size();
}

$('#mainform input[type=checkbox]').change(function () {
    var checked = CountCheckedInputs();
    ActionListChange(checked);
    if (checked==1) {
        ChangeEditHref();
    }
});
$('.action-slider').click(function () {
    var checked = CountCheckedInputs();
    ActionListChange(checked);
    if (checked == 1) {
        ChangeEditHref();
    }
});
function SendIdsToDelete() {
    var checkedIputs = $('#mainform input[type=checkbox]:checked');
    var idsArray = new Array();

    checkedIputs.each(function() {
        idsArray.push(this.id);
    });

 
    var postData = { ids: idsArray };

    $.ajax({
        type: "POST",
        url: "/Product/DeleteMultiple",
        data: postData,
        success: function (data) {
            alert(data.Result);
        },
        dataType: "json",
        traditional: true
    });
        
}

function ChangeEditHref() {
    var checkedIput = $('#mainform input[type=checkbox]:checked');
    $(".action-edit").attr("href", "/Product/Edit" + "/" + checkedIput[0].id);
}
        