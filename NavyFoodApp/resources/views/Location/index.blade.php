<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Locations') }}
        </h2>
    </x-slot>

    <div class="py-12, text-center">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">
                <table class="w=100">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>

                    @foreach($locations as $location)
                        <tr class="text-center">
                            <td>{{$location->id}}</td>
                            <td>{{$location->locationName}}</td>

                            <td>
                                <a href="{{route('location.edit', $location)}}">Edit</a>
                            </td>

                            <td>
                                <form method="POST" action="{{route('location.destroy', $location)}}">
                                    @method('DELETE')
                                    @csrf
                                    <button class="button button-red" type="submit">Delete</button>
                                </form>
                            </td>

                        </tr>

                    @endforeach
                </table>
            </div>

            <a href="{{route('location.create')}}" class="button">Create New</a>
        </div>
    </div>
</x-app-layout>
