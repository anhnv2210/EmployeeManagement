namespace ems_backend.Common.DefaultConstants
{
    public class Constants
    {
        public class AppSettingKeys
        {
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]";
            public const string DEFAULT_CONNECTION = "DefaultConnection";
        }
        public class ExceptionMessage
        {
            public const string SUCCESS = "Thành công.";
            public const string ITEM_NOT_FOUND = "không được tìm thấy bản ghi.";
            public const string CREATER_NOT_FOUND = "không được tìm thấy người tạo.";
            public const string UPDATER_NOT_FOUND = "Không tìm thấy người cập nhật.";
            public const string REQUEST_TO_FILL_INFORMATION = "Vui lòng điền đầy đủ thông tin";
            public const string ALREADY_EXIST = "{0} đã tồn tại.";
            public const string UPĐATE_SUCCESS = "Cập nhật thành công.";
            public const string DELETE_SUCCESS = "Xoá thành công.";
            public const string CREATE_SUCCESS = "Thêm thành công.";
            public const string INVALID = "Không hợp lệ.";
            public const string INVALID_EMAIL = "Email không hợp lệ.";
            public const string ALREADY_EMAIL_EXISTED = "Email đã tồn tại! Vui lòng thử lại";
            public const string ALREADY_PHONE_NUMBER_EXISTED = "Số điện thoại đã tồn tại! Vui lòng thử lại";
            public const string ALREADY_NAME_EXISTED = "Tên đã tồn tại! Vui lòng thử lại";
            public const string NOT_FOUND = "Không được tìm thấy.";
        }
    }
}
