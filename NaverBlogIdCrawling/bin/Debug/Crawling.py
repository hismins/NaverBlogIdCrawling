import os
import sys
import urllib
import urllib.request
client_id = "qJeO_bVBFPuLd7DZfxsP"
client_secret = "ldWECI0gDD"
Encoding_word = urllib.parse.quote("blog")
encText = urllib.parse.quote(Encoding_word)
url = "https://openapi.naver.com/v1/search/blog?query=" + encText # json 결과
# url = "https://openapi.naver.com/v1/search/blog.xml?query=" + encText # xml 결과
request = urllib.request.Request(url)
request.add_header("X-Naver-Client-Id",client_id)
request.add_header("X-Naver-Client-Secret",client_secret)
response = urllib.request.urlopen(request)
rescode = response.getcode()
if(rescode==200):
    response_body = response.read()
    print(response_body.decode('utf-8'))
else:
    print("Error Code:" + rescode)