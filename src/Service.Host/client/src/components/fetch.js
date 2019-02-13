const fetch = require('node-fetch');

fetch('http://app.linn.co.uk/intranet/menu', {
    headers: {
        Accept:
            'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8',
        'Cache-Control': 'max-age=0',
        mode: 'cors',
        credentials: 'same-origin',
        Cookie:
            '_ga=GA1.3.1767863748.1541167458; __utmz=140191532.1541770320.1.1.utmcsr=google^|utmccn=(organic)^|utmcmd=organic^|utmctr=(not^%^20provided); __utma=140191532.1767863748.1541167458.1541770320.1542706318.2; _gcl_au=1.1.810918352.1547638067; _fbp=fb.2.1549460928862.2024121082; .ASPXAUTH=F3E23C4CC6C2D87E14415F5921B25DEB5785623766195FA0208AE56AF63C3352681A3FE481ECD5E0B89BE33522EA8BB951D2C3391EB3D48C76DD687997AE7BDF4EF74E3C05228EE8298689EBB7F9F7C778DC61EB1EBD2E9A65D0EC79397C9A3779BF442B3C2F18B1077CA00722049935C20DCE0E; _gid=GA1.3.2007555162.1549875004'
    }
})
    .then(res => res.json())
    .then(json => {
        console.log(json);
    })
    .catch(err => {
        console.log(err);
    });
