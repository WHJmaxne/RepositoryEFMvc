(function ($) {
	$.fn.openloading = function (info) {
		//var $modal = $(this);
		var $modal = $(this);
		info = info == null ? '加载中...' : info;
		$modal.attr('class', 'modal fade').attr('data-keyboard', 'false').attr('data-backdrop', 'static').attr('data-role', 'dialog').attr('aria-labelledby', 'myModalLabel').attr('aria-hidden', 'true');
		var $showinfo = '<div id="myShowModalloading" style="width: 160px;height: 56px;position: absolute;top: 20%;left: 45%;line-height: 56px;color: #fff;padding-left: 60px;font-size: 15px;background: #000 url(/Content/Login/images/loading.gif) no-repeat 10px 50%;opacity: 0.7;z-index: 9999;-moz-border-radius: 20px;-webkit-border-radius: 20px;border-radius: 20px;filter: progid:DXImageTransform.Microsoft.Alpha(opacity=70);">' + info + '</div>';
		$modal.html($showinfo);
		$modal.modal('show');
	}
	$.fn.closeloading = function () {
		var $modal = $(this);
		$modal.modal('hide');
	}
})(jQuery);