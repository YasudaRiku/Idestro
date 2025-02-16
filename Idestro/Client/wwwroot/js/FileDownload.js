//JavaScriptテスト用
export function outputLog(obj) {
    console.log(typeof obj, obj);
}

export function downloadFileFromStream(url, fileDesc) {
    // a タグ生成
    var alink = document.createElement('a');
    alink.download = fileDesc;  // [download] のファイル名
    alink.href = url;           // サーバのファイルのURL
    alink.click();              // クリック実行
    return false;
}
