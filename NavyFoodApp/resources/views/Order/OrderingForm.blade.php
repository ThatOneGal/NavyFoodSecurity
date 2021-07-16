<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('OrderingForm') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">


                <form action="#" method="POST">
                    @csrf
                    <div>
                        <h1>Ordering Form</h1>
                    </div>
                    <div> {{--Destination--}}
                        <div>
                            <label for="Location">Destination</label>
                        </div>

                        <div>
                            {{--<input type="select" name="Location" list="LocationList" --}}{{--Location variable--}}{{--/>--}}

                            <select name="Location" id="LocationList">
                                @foreach($LocationList as $Location)
                                    <option value="{{$Location->id}}">{{$Location->Name}}</option>
                                @endforeach
                                <option value="Base">Base</option>
                                <option value="Kitchen">Kitchen</option>
                                <option value="DeliverySector">DeliverySector</option>
                            </select>
                        </div>
                    </div>



                    <div> {{--Order Name--}}
                        <div>
                            <label for="CustomerId">Order Recipient</label>
                        </div>

                        <div>
                            <input type="text" id="CustomerId" value="{Rank}{Name} {{--Variable for users details--}} " readonly>
                        </div>
                    </div>

                    <div>{{--Order List--}}
                        <div>
                            <label for="Content">Content:</label>
                        </div>

                        <div>
                            <textarea name="Content" id="Content" cols="30" rows="10">
                                {{--content list of data--}}
                            </textarea>
                        </div>
                    </div>

                    <div> {{--Notes--}}
                        <div>
                            <label for="Notes">Notes:</label>
                        </div>
                        <div>
                            <textarea name="Notes" id="Notes" cols="30" rows="10">
                                {{--content list of data--}}
                            </textarea>
                        </div>

                    </div>
                    <div>
                        <input type="submit" value="Submit">
                        <input type="reset" value="Cancel">

                    </div>

                </form>


            </div>
        </div>
    </div>
</x-app-layout>
