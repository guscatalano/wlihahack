# IO.Swagger.Api.TenantApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiTenantGet**](TenantApi.md#apitenantget) | **GET** /api/Tenant | 
[**ApiTenantIdDelete**](TenantApi.md#apitenantiddelete) | **DELETE** /api/Tenant/{id} | 
[**ApiTenantIdGet**](TenantApi.md#apitenantidget) | **GET** /api/Tenant/{id} | 
[**ApiTenantIdPut**](TenantApi.md#apitenantidput) | **PUT** /api/Tenant/{id} | 
[**ApiTenantPost**](TenantApi.md#apitenantpost) | **POST** /api/Tenant | 

<a name="apitenantget"></a>
# **ApiTenantGet**
> List<string> ApiTenantGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTenantGetExample
    {
        public void main()
        {
            var apiInstance = new TenantApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ApiTenantGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantApi.ApiTenantGet: " + e.Message );
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
<a name="apitenantiddelete"></a>
# **ApiTenantIdDelete**
> void ApiTenantIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTenantIdDeleteExample
    {
        public void main()
        {
            var apiInstance = new TenantApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ApiTenantIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantApi.ApiTenantIdDelete: " + e.Message );
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
<a name="apitenantidget"></a>
# **ApiTenantIdGet**
> TenantInfo ApiTenantIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTenantIdGetExample
    {
        public void main()
        {
            var apiInstance = new TenantApi();
            var id = 56;  // int? | 

            try
            {
                TenantInfo result = apiInstance.ApiTenantIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantApi.ApiTenantIdGet: " + e.Message );
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

[**TenantInfo**](TenantInfo.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apitenantidput"></a>
# **ApiTenantIdPut**
> void ApiTenantIdPut (int? id, string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTenantIdPutExample
    {
        public void main()
        {
            var apiInstance = new TenantApi();
            var id = 56;  // int? | 
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiTenantIdPut(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantApi.ApiTenantIdPut: " + e.Message );
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
<a name="apitenantpost"></a>
# **ApiTenantPost**
> void ApiTenantPost (CompleteTenantEvictionInfo body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiTenantPostExample
    {
        public void main()
        {
            var apiInstance = new TenantApi();
            var body = new CompleteTenantEvictionInfo(); // CompleteTenantEvictionInfo |  (optional) 

            try
            {
                apiInstance.ApiTenantPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantApi.ApiTenantPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CompleteTenantEvictionInfo**](CompleteTenantEvictionInfo.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
