// Be sure to install axios and qs with the following command
// npm install --save axios qs

const axios = require('axios');
const qs = require('qs');

axios({
    method: 'post',
    url: 'https://api.jangomail.com/api.asmx/SendMassEmail',
    data: qs.stringify({
      'Username': '',
      'Password': '',
      'FromEmail': '',
      'FromName': '',
      'ToGroups': '',
      'ToGroupFilter': '',
      'ToOther': '',
      'ToWebDatabase': '',
      'Subject': '',
      'MessagePlain': '',
      'MessageHTML': '',
      'Options': ''
    }),
    headers: {
      'Content-type': 'application/x-www-form-urlencoded'
    }
  })
  .then(function (response) {
    console.log(response.data);
  })
  .catch(function (error) {
    console.log(`${error.response.status}: ${error.response.statusText} - ${error.response.data}`);
  });