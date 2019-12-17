function readURL(input) {
  if (input.files && input.files[0]) {
    var reader = new FileReader();
    
    reader.onload = function(e) {
        $('#imgInp').attr('value', e.target.result);
    }
    
    reader.readAsDataURL(input.files[0]);
  }
}

$("#imgInp").change(function() {
  readURL(this);
});


$("#btn").click(function () {
    $.getJSON("/News/Home/All", function (data) {
        console.log(data)

        $("#content").html("");

        data.forEach(element => {
            $("#content").append(`<div>
                <h3>
                    `+ element.Text + `
                </h3>
                <img src="`+ element.ImagePath + `" />

            </div>`)
        });
    });
});

/*

<script src="~/Scripts/jquery-3.3.1.min.js"></script>
<script>

    $("#btn").click(function () {
        $.getJSON("/News/Home/All", function (data) {
            console.log(data)

            $("#content").html("");

            data.forEach(element => {
                $("#content").append(`<div>
                <h3>
                    `+ element.Text + `
                </h3>
                <img src="`+ element.ImagePath + `" />

            </div>`)
            });
        });
    });

</script>
 */