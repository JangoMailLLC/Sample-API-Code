# Install the Python Requests library:
# `pip install requests`

import requests


def send_request():
    # SendTransactionalEmail
    # POST https://api.jangomail.com/api.asmx/SendTransactionalEmail

    try:
        response = requests.post(
            url="https://api.jangomail.com/api.asmx/SendTransactionalEmail",
            headers={
                "Content-Type": "application/x-www-form-urlencoded; charset=utf-8",
            },
            data={
                "Username": "",
                "Password": "",
                "FromEmail": "",
                "FromName": "",
                "ToEmailAddress": "",
                "Subject": "",
                "MessagePlain": "",
                "MessageHTML": "",
                "Options": "",
            },
        )
        print('Response HTTP Status Code: {status_code}'.format(
            status_code=response.status_code))
        print('Response HTTP Response Body: {content}'.format(
            content=response.content))
    except requests.exceptions.RequestException:
        print('HTTP Request failed')

send_request();
