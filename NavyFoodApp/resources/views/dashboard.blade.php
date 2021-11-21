<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Dashboard') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                {{--
                                <form method="GET" action="{{view('/showID'),['OrderNum']}}">
                --}}
                <form method="GET" action="{{route('showById'),}}" style="margin-top: 10px; margin-bottom: 10px">
                @csrf

                <div style="text-align: center; padding-bottom:10px;">
                    <Label>ID to Display</Label>

                    <input name="id" type="text" value=""/>

                </div>
                <div style="text-align: center; border: black">
                    <input type="submit" />
                </div>
                </form>

            </div>
        </div>
    </div>
</x-app-layout>
