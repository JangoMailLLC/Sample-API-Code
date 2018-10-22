<?php

// get cURL resource
$ch = curl_init();

// set url
curl_setopt($ch, CURLOPT_URL, 'https://api.jangomail.com/api.asmx/SendMassEmail');

// set method
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');

// return the transfer as a string
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);

// set headers
curl_setopt($ch, CURLOPT_HTTPHEADER, [
  'Content-Type: application/x-www-form-urlencoded; charset=utf-8',
]);

// form body
$body = [
  'Username' => '',
  'Password' => '',
  'FromEmail' => '',
  'FromName' => '',
  'ToGroups' => '',
  'ToGroupFilter' => '',
  'ToOther' => '',
  'ToWebDatabase' => '',
  'Subject' => '',
  'MessagePlain' => '',
  'MessageHTML' => '',
  'Options' => '',
];
$body = http_build_query($body);

// set body
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $body);

// send the request and save response to $response
$response = curl_exec($ch);

// stop if fails
if (!$response) {
  die('Error: "' . curl_error($ch) . '" - Code: ' . curl_errno($ch));
}

echo 'HTTP Status Code: ' . curl_getinfo($ch, CURLINFO_HTTP_CODE) . PHP_EOL;
echo 'Response Body: ' . $response . PHP_EOL;

// close curl resource to free up system resources 
curl_close($ch);


