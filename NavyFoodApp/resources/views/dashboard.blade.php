<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Dashboard') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                @php

                    /*$image = new Imagick();
                    $image->setBackgroundColor(new ImagickPixel('transparent'));
                    $image->readImageBlob(file_get_contents('images/qrcode.svg'));
                    $image->setImageFormat(".png24");
                    $image->resizeImage(500, 500, imagick::FILTER_LANCZOS, 1, 1);
                    $image->writeImage('qrcode.png');
                    file_put_contents('qrcode.png', $image);*/



                    if(isset($_GET['qrcode']))

{

    $link=$_GET['qrcode'];
    $file = basename($link);
    $file = basename($link, ".svg");
    $path="/public/images/";
    $im = new Imagick();
    $svg = file_get_contents($link);
    $im->readImageBlob($svg);
    $im->setImageFormat("png24");
    $im->writeImage("/public/images/$file.png");
    $im->clear();
    $im->destroy();

}

    //$url = ("http://example.com/files/");
    $result = ("/public/images/" . "qrcode" . ".png");
    $arr = array('url' => $result);

    echo json_encode($arr);


                    $QRCodeReader = new Libern\QRCodeReader\QRCodeReader();
                    $qrcode_text = $QRCodeReader->decode('/public/images/qrcode.png');
                    echo $qrcode_text;

                @endphp

            </div>
        </div>
    </div>
</x-app-layout>
