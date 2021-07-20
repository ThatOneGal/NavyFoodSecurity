<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Dashboard') }}
        </h2>
    </x-slot>

    <div class="py-12">s
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                {{--
                                <form method="GET" action="{{view('/showID'),['OrderNum']}}">
                --}}
                <form method="POST" action="/showID/{{'id'}}">
                    @csrf

                    <div style="text-align: left; padding-bottom:4px;">
                        <Label>ID to Display </Label>

                        <input name="id" type="number"/>
                    </div>
                    <div style="text-align: center;">
                        <input type="submit" class="button"/>
                    </div>
                </form>

            </div>
        </div>
    </div>
</x-app-layout>
