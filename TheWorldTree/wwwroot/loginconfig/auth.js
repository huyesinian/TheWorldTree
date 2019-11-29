
$(function () {
	$("#Login").click(function () {
		LoginSys();
	});
});

function LoginSys() {
	if ($.trim($("#name").val()) == "") {
		$("#tips").html("�û�������Ϊ�գ�");
		return;
	}
	if ($.trim($("#password").val()) == "") {
		$("#tips").html("���벻��Ϊ�գ�");
		return;
	}
	$.post('/Account/Login', { UserName: $("#name").val(), Password: $("#password").val()},
		function (data) {
			if (data.type == "1") {
				var url = getQueryString("url");
				if (url != null) {
					window.location = url;
				}
				else {
					window.location = "/" + $("#local").val() + "/Home/Index";
				}
			} else {
				$("#tips").html(data.message);
			}
		}, "json");
	return false;
}