<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('History') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w17xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto">
                    {{--Table header--}}
                    <thead>
                    <tr>
                        <th>Order Id</th>
                        <th>Destination</th>
                        <th>Recipient</th>
                        <th>Status</th>
                        <th>Created</th>
                        <th>Shipped</th>
                        <th class>Packed</th>
                        <th>Packaged Qty</th>
                        <th>Content</th>
                        <th>Notes Storage</th>
                        <th>Notes Preparation</th>
                    </tr>
                    </thead>
                    <tbody>
                    @foreach($orderList as $order)
                        <tr class="border">
                            <td><label class="col-sm-2" for="">{{$order->id}}</label></td>
                            <td>
                                @foreach($locationList as $location)
                                    @if ($order->LocationId == $location->id)
                                        {{$location->locationName}}
                                    @endif
                                @endforeach
                            </td>
                            <td>{{$order->CustomerId}}</td>
                            <td>
                                @foreach($statusList as $status)
                                    @if ($order->StatusId == $status->id)
                                        {{$status->statusName}}
                                    @endif
                                @endforeach
                            </td>
                            <td>{{$order->OrderDate}}</td>
                            <td>
                                @if($order->OrderShipped == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderShipped}}
                                @endif
                            </td>
                            <td>
                                @if($order->OrderPacked == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$order->OrderPacked}}
                                @endif
                            </td>
                            <td>{{$order->PackageQty}}</td>
                            <td>{{$order->Content}}</td>
                            <td>{{$order->NotesStorage}}</td>
                            <td>{{$order->NotesPreparation}}</td>
                            <td><a href="{{route('order.edit', $order)}}">
                                    <button class='button button-primary' type="submit">Edit</button>
                                </a>

                                <form method="POST" action="{{route('order.destroy', $order)}}">
                                    @csrf
                                    @method('DELETE')
                                    <button class='button button-primary' type="submit">Delete</button>
                                </form>
                            </td>
                        </tr>
                    @endforeach
                    </tbody>
                </table>

            </div>
        </div>
    </div>
</x-app-layout>