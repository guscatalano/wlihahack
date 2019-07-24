# IO.Swagger.Api.AddressApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAddressGet**](AddressApi.md#apiaddressget) | **GET** /api/Address | 
[**ApiAddressIdDelete**](AddressApi.md#apiaddressiddelete) | **DELETE** /api/Address/{id} | 
[**ApiAddressIdGet**](AddressApi.md#apiaddressidget) | **GET** /api/Address/{id} | 
[**ApiAddressIdPut**](AddressApi.md#apiaddressidput) | **PUT** /api/Address/{id} | 
[**ApiAddressPost**](AddressApi.md#apiaddresspost) | **POST** /api/Address | 

<a name="apiaddressget"></a>
# **ApiAddressGet**
> List<string> ApiAddressGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAddressGetExample
    {
        public void main()
        {
            var apiInstance = new AddressApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ApiAddressGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AddressApi.ApiAddressGet: " + e.Message );
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
<a name="apiaddressiddelete"></a>
# **ApiAddressIdDelete**
> void ApiAddressIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAddressIdDeleteExample
    {
        public void main()
        {
            var apiInstance = new AddressApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ApiAddressIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AddressApi.ApiAddressIdDelete: " + e.Message );
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
<a name="apiaddressidget"></a>
# **ApiAddressIdGet**
> AddressInfo ApiAddressIdGet (string id, int? addressId = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAddressIdGetExample
    {
        public void main()
        {
            var apiInstance = new AddressApi();
            var id = id_example;  // string | 
            var addressId = 56;  // int? |  (optional) 

            try
            {
                AddressInfo result = apiInstance.ApiAddressIdGet(id, addressId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AddressApi.ApiAddressIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **addressId** | **int?**|  | [optional] 

### Return type

[**AddressInfo**](AddressInfo.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiaddressidput"></a>
# **ApiAddressIdPut**
> void ApiAddressIdPut (int? id, string body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAddressIdPutExample
    {
        public void main()
        {
            var apiInstance = new AddressApi();
            var id = 56;  // int? | 
            var body = new string(); // string |  (optional) 

            try
            {
                apiInstance.ApiAddressIdPut(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AddressApi.ApiAddressIdPut: " + e.Message );
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
<a name="apiaddresspost"></a>
# **ApiAddressPost**
> void ApiAddressPost (AddressInfo body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAddressPostExample
    {
        public void main()
        {
            var apiInstance = new AddressApi();
            var body = new AddressInfo(); // AddressInfo |  (optional) 

            try
            {
                apiInstance.ApiAddressPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AddressApi.ApiAddressPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AddressInfo**](AddressInfo.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
