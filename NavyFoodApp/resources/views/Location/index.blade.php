<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Locations') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto" style="align-content: center">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>

                    @foreach($locations as $location)
                        <tr>
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
                </table>

                <div style="align-content: center">
                    <a href="{{route('location.create')}}" style="background: #efefef; border: black;"
                        class="button">Create New</a>
                </div>

            </div>
        </div>
    </div>
</x-app-layout>
