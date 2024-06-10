function GetAjax(url, PopupReplaceId) {
    
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
          
            $(PopupReplaceId).html('');
            $(PopupReplaceId).html(response);

        }, error: function (xhr) {
            alert("Something Webt Wron Please Try Again")
            console.log(xhr.responseText);
        }
    })
}


function PostAjax(url, formData, ReplcaeTableId, PopupId, PopupReplaceId,Message) {


    $.ajax({
        type: "POST",
        url: url,
        dataType: 'json',
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {

            if (response.isValid == true) {
                 swal(Message, 'Success');
                $(PopupId).modal('hide')
                $(ReplcaeTableId).html(response.message)


            } else {
                $(PopupReplaceId).html(response.message);
            }

        }, error: function (xhr) {
            alert("Something Webt Wron Please Try Again")
            console.log(xhr.responseText);
        }

    })
}



function DeletePostAjax(url,SuccessMessge,ReplcaeTableId) {
    $.ajax({
        type: "POST",
        url: url,
        success: function (response)
        {

            swal(SuccessMessge, 'Success');
            $(ReplcaeTableId).html(response.message)
        },
        error: function (xhr) {
            alert("Something Webt Wron Please Try Again")
            console.log(xhr.responseText);
        }
    })
}


function PostAutoComplete(request, response,url) {
    
        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            data: {
                term: request.term
            },
            success: function (data) {
                let suggestions = Array.isArray(data) ? data : data.message;
                response(suggestions);
            }, error: function (xhr) {
                alert("Something Webt Wron Please Try Again")
                console.log(xhr.responseText);


            }

        });
    
  
}