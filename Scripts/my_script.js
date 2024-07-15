var CourseCategories = []
function LoadCategory(element) {
    if (CourseCategories.length == 0) {
        $.ajax({
            type: "GET",
            url: '/TraineeView/getCourseCategories',
            success: function (data) {
                CourseCategories = data;
                renderCategory(element);
            }
        })
    }
    else {
        renderCategory(element);
    }
}


function renderCategory(element) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(CourseCategories, function (i, val) {
        $ele.append($('<option/>').val(val.CourseCategoryId).text(val.CategoryName));
    })
}


function LoadCourse(categoryDD) {

    $.ajax({
        type: "GET",
        url: '/TraineeView/getCourse',
        data: { 'courseCategoryId': $(categoryDD).val() },
        success: function (data) {

            renderCourse($(categoryDD).parents('.mycontainer').find('select.course'), data);
        },
        error: function (error) {
            console.log(error)
        }
    })
}

function renderCourse(element, data) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.CourseId).text(val.CourseName));
    })
}



$(document).ready(function () {
    // Image Section
    //var formData = new FormData();
    //formData.append('file', $('#imageupload')[0].file[0]);

    //Add Course
    $("#add").click(function () {
        var isAllvalid = true;
        if ($('#courseCategory').val() == "0") {
            isAllvalid = false;
            $('#courseCategory').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#courseCategory').siblings('span.error').css('visibility', 'hidden');
        }

        //Course
        if ($('#course').val() == "0") {
            isAllvalid = false;
            $('#course').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#course').siblings('span.error').css('visibility', 'hidden');
        }

        //Course Duration
        if (!$('#duration').val().trim() != "" && (parseInt($('#duration').val()) || 0)) {
            isAllValid = false;
            $('#duration').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#duration').siblings('span.error').css('visibility', 'hidden');
        }



        //Course Fee
        if (!$('#fee').val().trim() != "" && (!isNaN($('#fee').val().trim()))) {
            isAllValid = false;
            $('#fee').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#fee').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllvalid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.cc', $newRow).val($('#courseCategory').val());
            $('.course', $newRow).val($('#course').val());
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
            $('#courseCategory, #course, #duration, #fee, #add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            $('#courseDetailsItems').append($newRow);
            $('#courseCategory, #course').val('0');
            $('#duration, #fee').val('');
            $("#courseItemError").empty();
        }
    });

    // Remove Course
    $('#courseDetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    //Enroll Course
    $('#submit').click(function () {
        var isAllValid = true;
        $('#courseItemError').text('');
        var list = []
        var errorItemCount = 0;

        //course add to list
        $('#courseDetailsItems tbody tr').each(function (index, ele) {
            if ($('select.course', this).val() == "0" ||
                $('.duration', this).val() == "" ||
                $('.fee', this).val() == "" ||
                isNaN($('.fee', this).val()))
            {
                errorItemCount++;
                $(this).addClass('error');
            }
            else {
                var courseList = {
                    CourseId: $('select.course', this).val(),
                    Duration: $('.duration', this).val(),
                    CourseFee: parseFloat($('.fee', this).val())
                }
                console.log(courseList);
                console.log("courseList");
                list.push(courseList);
            }
        })
        console.log(list);
        //error count and validation
        if (errorItemCount > 0) {
            $('#courseItemError').text(errorItemCount + " Invalid entry in course list!!!");
            isAllValid = false;
        }
        //No. of Item check
        if (list.length == 0) {
            $('#courseItemError').text(" At least one entry is required to course an item!!!");
            isAllValid = false;
        }
        //date get
        if ($('#dob').val().trim() == '') {
            $('#dob').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#dob').siblings('span.error').css('visibility', 'hidden');
        }

        //order submit
        if (isAllValid) {
            var data = {
                TraineeName: $('#tName').val().trim(),
                FatherName: $('#fName').val().trim(),
                Gender: $('#gender').val().trim(),
                DateOfBirth: $('#dob').val().trim(),
                Address: $('#address').val().trim(),
                Email: $('#email').val(),
                Image: $('#imageupload').val().trim(),
                Terms: $('#bool').is('.checked'),
                TraineeDetails: list
            }
            console.log(data);
            $(this).val('Please Wait................')

            $.ajax({
                type: "POST",
                url: '/TraineeView/Save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert("Enroll Placed successfully!!!!!!!!!!!")
                        list = [];
                        $('#tName,#fName,#dob,#address,#email,#imageupload,#bool').val('');
                        $('#courseDetailsItems').empty();

                        //parsed order 
                        //window.location = '/Order/List';
                    }
                    else {
                        alert('********ERROR********')
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error)
                    $('#submit').val('Save');
                }
            })
        }

    });

});

LoadCategory($('#courseCategory'));