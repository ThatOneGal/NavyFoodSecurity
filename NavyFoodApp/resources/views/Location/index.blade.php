<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Locations') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto" cellpadding="15" cellspacing="15" style="margin-top: 10px; margin-bottom: 4px">
                    {{--Table header--}}
                    <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                    </thead>
                    <tbody>
                    @foreach($locations as $location)
                        <tr class="border">
                            <td>{{$location->id}}</td>
                            <td>{{$location->locationName}}</td>

                            <td>
                                <a href="{{route('location.edit', $location)}}"
                                   style="background: #efefef; border: black; ">Edit</a>

                                <form method="POST" action="{{route('location.destroy', $location)}}">
                                    @method('DELETE')
                                    @csrf
                                    <button class="button button-red" style="background: #efefef; border: black;"
                                            type="submit">Delete
                                    </button>
                                </form>
                            </td>
                        </tr>

                    @endforeach
                    </tbody>
                </table>

                <div style="text-align: center; margin-top: 10px; margin-bottom: 10px">
                    <a href="{{route('location.create')}}" style="background: #efefef; border: black;"
                        class="button">Create New</a>
                </div>
            </div>
        </div>
    </div>
</x-app-layout>
