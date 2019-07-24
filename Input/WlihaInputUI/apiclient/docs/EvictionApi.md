# IO.Swagger.Api.EvictionApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiEvictionGet**](EvictionApi.md#apievictionget) | **GET** /api/Eviction | 
[**ApiEvictionIdDelete**](EvictionApi.md#apievictioniddelete) | **DELETE** /api/Eviction/{id} | 
[**ApiEvictionIdGet**](EvictionApi.md#apievictionidget) | **GET** /api/Eviction/{id} | 
[**ApiEvictionIdPut**](EvictionApi.md#apievictionidput) | **PUT** /api/Eviction/{id} | 
[**ApiEvictionPost**](EvictionApi.md#apievictionpost) | **POST** /api/Eviction | 

<a name="apievictionget"></a>
# **ApiEvictionGet**
> List<string> ApiEvictionGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiEvictionGetExample
    {
        public void main()
        {
            var apiInstance = new EvictionApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ApiEvictionGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EvictionApi.ApiEvictionGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apievictioniddelete"></a>
# **ApiEvictionIdDelete**
> void ApiEvictionIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiEvictionIdDeleteExample
    {
        public void main()
        {
            var apiInstance = new EvictionApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ApiEvictionIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EvictionApi.ApiEvictionIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apievictionidget"></a>
# **ApiEvictionIdGet**
> string ApiEvictionIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiEvictionIdGetExample
    {
        public void main()
        {
            var apiInstance = new EvictionApi();
            var id = 56;  // int? | 

            try
            {
                string result = apiInstance.ApiEvictionIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EvictionApi.ApiEvictionIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apievictionidput"></a>
# **ApiEvictionIdPut**
> void ApiEvictionIdPut (int? id, string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiEvictionIdPutExample
    {
        public void main()
        {
            var apiInstance = new EvictionApi();
            var id = 56;  // int? | 
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiEvictionIdPut(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EvictionApi.ApiEvictionIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apievictionpost"></a>
# **ApiEvictionPost**
> void ApiEvictionPost (string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiEvictionPostExample
    {
        public void main()
        {
            var apiInstance = new EvictionApi();
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiEvictionPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EvictionApi.ApiEvictionPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
