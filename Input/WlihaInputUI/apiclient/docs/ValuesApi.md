# IO.Swagger.Api.ValuesApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiValuesGet**](ValuesApi.md#apivaluesget) | **GET** /api/Values | 
[**ApiValuesIdDelete**](ValuesApi.md#apivaluesiddelete) | **DELETE** /api/Values/{id} | 
[**ApiValuesIdGet**](ValuesApi.md#apivaluesidget) | **GET** /api/Values/{id} | 
[**ApiValuesIdPut**](ValuesApi.md#apivaluesidput) | **PUT** /api/Values/{id} | 
[**ApiValuesPost**](ValuesApi.md#apivaluespost) | **POST** /api/Values | 

<a name="apivaluesget"></a>
# **ApiValuesGet**
> List<string> ApiValuesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesGetExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ApiValuesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesGet: " + e.Message );
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
<a name="apivaluesiddelete"></a>
# **ApiValuesIdDelete**
> void ApiValuesIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesIdDeleteExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ApiValuesIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesIdDelete: " + e.Message );
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
<a name="apivaluesidget"></a>
# **ApiValuesIdGet**
> string ApiValuesIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesIdGetExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 

            try
            {
                string result = apiInstance.ApiValuesIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesIdGet: " + e.Message );
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
<a name="apivaluesidput"></a>
# **ApiValuesIdPut**
> void ApiValuesIdPut (int? id, string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesIdPutExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiValuesIdPut(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesIdPut: " + e.Message );
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
<a name="apivaluespost"></a>
# **ApiValuesPost**
> void ApiValuesPost (string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesPostExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiValuesPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesPost: " + e.Message );
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
