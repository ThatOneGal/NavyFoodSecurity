<x-app-layout>
    <x-slot name="header">
        <h2 class="font-semibold text-xl text-gray-800 leading-tight">
            {{ __('History') }}
        </h2>
    </x-slot>

    <div class="py-12">
        <div class="max-w17xl mx-auto sm:px-6 lg:px-8">
            <div class="bg-white overflow-hidden shadow-xl sm:rounded-lg">

                <table class="mx-auto" cellpadding="5" cellspacing="5" style="margin-top: 10px; margin-bottom: 10px">
                    {{--Table header--}}
                    <thead>
                    <tr>
                        <th>Order ID</th>
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
                            <td style="text-align: center"><label class="col-sm-2" for="">{{$order->id}}</label></td>
                            <td style="text-align: center">
                                @foreach($locationList as $location)
                                    @if ($order->LocationId == $location->id)
                                        {{$location->locationName}}
                                    @endif
                                @endforeach
                            </td>
                            <td style="text-align: center">{{$order->CustomerId}}</td>
                            <td style="text-align: center">
                                @foreach($statusList as $status)
                                    @if ($order->StatusId == $status->id)
                                        {{$status->statusName}}
                                    @endif
                                @endforeach
                            </td>
                            <td style="text-align: center">{{$order->OrderDate}}</td>
                            <td style="text-align: center">
                                @if($order->OrderShipped == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$Order->OrderShipped}}
                                @endif
                            </td>
                            <td style="text-align: center">
                                @if($order->OrderPacked == null)
                                    0000-00-00 00:00:00
                                @else
                                    {{$order->OrderPacked}}
                                @endif
                            </td>
                            <td style="text-align: center">{{$order->PackageQty}}</td>
                            <td style="text-align: center">{{$order->Content}}</td>
                            <td style="text-align: center">{{$order->NotesStorage}}</td>
                            <td style="text-align: center">{{$order->NotesPreparation}}</td>
                            <td style="text-align: center">
                                <a href="{{route('order.edit', $order)}}">
                                    <button class='button button-primary' type="submit" style="background: #efefef; border: black; margin-bottom: 3px;">Edit</button>
                                </a>

                                <form method="POST" action="{{route('order.destroy', $order)}}">
                                    @csrf
                                    @method('DELETE')
                                    <button class='button button-primary' type="submit" style="background: #efefef; border: black">Delete</button>
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
