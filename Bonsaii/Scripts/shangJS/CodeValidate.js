   $(document).ready(function () {
        $('#Code').attr('readOnly', 'true');
        $('#Code').val("YYYYMMDD**");

        $('#CodeMethod').change(function () {
            $('#Code ~ span').text("");
            var method = $('#CodeMethod').val();
            var tmp;
            if (method == '日编+流水') {
                $('#Code').attr('readOnly', 'true');
                tmp = "YYYYMMDD**";
            }
            if (method == '月编+流水') {
                $('#Code').attr('readOnly', 'true');
                tmp = "YYYYMM****";
            }
            if (method == '流水') {
                $('#Code').removeAttr('readOnly');
            }
            if (method == '手动设置') {
                $('#Code').attr('readOnly', 'true');
                tmp = "";
            }
            $('#Code').val(tmp);
            $('#Code').attr('value', tmp);

        });

        $('#Code').blur(function () {
            var code = $('#Code').val();
            var reg = /^[a-zA-Z]{0,8}\**$/;
            var regLen = /([A-Za-z]|\*){10}/;
            if (regLen.test(code) && reg.test(code)) {
                return
            }
            else {
                $('#Code ~ span').text("流水编码格式输入错误");
            }
        });
    });