
<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Dashboard') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                {!! $image = "images/qrcode.svg" !!}
                {!! $QRCodeReader = new Libern\QRCodeReader\QRCodeReader(); !!}
                {!! $qrcode_text = $QRCodeReader->decode(base64_encode($image)); !!}
                {!! print $qrcode_text !!}

{{--                {!! $qrcode = new Zxing\QrReader($image); !!}
                {!! $text = $qrcode->text(); !!} //return decoded text from QR Code --}}

            </div>
        </div>
    </div>
</x-app-layout>
