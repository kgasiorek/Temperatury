function printDiv() {
    var printContents = document.getElementById("report").innerHTML;
    var iframe = document.createElement('iframe');
    iframe.style.display = 'none';
    document.body.appendChild(iframe);
    iframe.contentDocument.write('<html><head><title>Print</title>');
    iframe.contentDocument.write('<link rel="stylesheet" href="_content/MudBlazor/MudBlazor.min.css" type="text/css" />');
    iframe.contentDocument.write('<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" type="text/css" />');
    iframe.contentDocument.write('<link rel="stylesheet" href="Temperatury.styles.css" type="text/css" />');
    iframe.contentDocument.write('<link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" type="text/css" />');
    iframe.contentDocument.write('<link rel="stylesheet" href="css/site.css" type="text/css" />');
    iframe.contentDocument.write('</head><body>');
    iframe.contentDocument.write(printContents);
    iframe.contentDocument.write('</body></html>');
    iframe.contentDocument.close();
    iframe.onload = function () {
        iframe.contentWindow.print();
        document.body.removeChild(iframe);
    }
}