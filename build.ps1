if (!(Test-Path ".\src\opencv"))
{
    $targetFile = ".\src\opencv-redist.exe"
    $targetHash = "7CB3D1445F0AC935CF174BD0FE4E3779"
    $uri = "https://sourceforge.net/projects/opencvlibrary/files/opencv-win/2.4.13/opencv-2.4.13.6-vc14.exe"
    $webclient = New-Object System.Net.WebClient
    Write-Host ("Downloading OpenCV redistributable from:", $uri)
    $webclient.DownloadFile($uri,$targetFile)
    $fileHash = Get-FileHash $targetFile -Algorithm MD5
    Write-Output $fileHash
    if ($targetHash -eq $fileHash.Hash)
    {
        $process = Start-Process $targetFile "-y" -PassThru
        $process.WaitForExit()
    }
}
& dotnet build -c Release .\src\OpenCV.Net.sln