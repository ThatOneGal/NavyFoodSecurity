<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('Order:') }} {{$Order->id}}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w-7xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">


                <form action="{{route('order.update', $Order)}}" method="POST">
                    @csrf
                    @method('PUT')
                    <div> {{--Destination--}}
                        <div><label for="Location">Destination</label></div>
                        <div>
                            <select name="LocationId" id="LocationId">
                                @foreach($locationList as $location)

                                    @if ($Order->LocationId == $location->id)
                                        <option value="{{$location->id}}" selected>{{$location->locationName}}</option>

                                    @else
                                        <option value="{{$location->id}}">{{$location->locationName}}</option>

                                    @endif
                                @endforeach
                            </select>
                        </div>
                    </div>


                    <div> {{--Status--}}
                        <div><label for="Status">Status</label></div>

                        <div>
                            <select name="StatusId" id="StatusId">

                                @foreach($statusList as $status)
                                    @if ($Order->StatusId == $status->id)

                                        <option value="{{$status->id}}" selected>{{$status->statusName}}</option>

                                    @else
                                        <option value="{{$status->id}}">{{$status->statusName}}</option>

                                    @endif
                                @endforeach
                            </select>
                        </div>
                    </div>


                    <div> {{--Order Date--}}
                        <div>
                            <label for="OrderDate">Date Ordered:</label>
                        </div>
                        <div>
                            <label for="OrderDate">{{$Order->OrderDate}}</label>
                        </div>
                    </div>

                    <div> {{--Order Shipped--}}
                        <div>
                            <label for="OrderShipped">Date Shipped:</label>
                        </div>
                        <div>
                            <label for="OrderShipped">
                                @if($Order->OrderShipped == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderShipped}}
                                @endif </label>
                        </div>
                    </div>

                    <div> {{--Order Packed--}}
                        <div>
                            <label for="OrderPacked">Date Packed:</label>
                        </div>
                        <div>
                            <label for="OrderPacked">
                                @if($Order->OrderPacked == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderPacked}}
                                @endif
                            </label>
                        </div>
                    </div>


                    <div> {{--Packaged Qty--}}
                        <div>
                            <label for="PackageQty">Package Qty:</label>
                        </div>
                        <div>
                            <textarea name="PackageQty" id="PackageQty" cols="0"
                                      rows="0">{{$Order->PackageQty}}</textarea>
                        </div>

                    </div>

                    <div> {{--Order Name--}}
                        <div>
                            <label for="CustomerId">Order Recipient</label>
                        </div>

                        <div>
                            <input type="text" id="CustomerId"
                                   value="{{$Order->CustomerId }} {{--Variable for users details--}} " readonly>
                        </div>
                    </div>


                    <div>{{--Order Content--}}
                        <div>
                            <label for="Content">Content:</label>
                        </div>

                        <div>
                            <textarea name="Content" id="Content" cols="0" rows="0">{{$Order->Content}}</textarea>
                        </div>
                    </div>

                    <div> {{--Notes Storage--}}
                        <div>
                            <label for="NotesStorage">Notes:</label>
                        </div>
                        <div>
                            <textarea name="NotesStorage" id="NotesStorage" cols="0"
                                      rows="0">{{$Order->NotesStorage}}</textarea>
                        </div>


                        <div> {{--Notes Preparation--}}
                            <div>
                                <label for="NotesPreparation">Notes Preparation :</label>
                            </div>
                            <div>
                            <textarea name="NotesPreparation" id="NotesPreparation" cols="0"
                                      rows="0">{{$Order->NotesPreparation}}</textarea>
                            </div>

                        </div>
                        <div>
                            <input type="submit" value="Submit">

                        </div>
                        <div>
                            <input type="reset" value="Cancel">
                        </div>

                </form>


            </div>
        </div>
    </div>
</x-app-layout>
