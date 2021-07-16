<div class="flex">
    <!-- Logo -->
    <div class="flex-shrink-0 flex items-center">
        <a href="{{ route('dashboard') }}">
            <x-jet-application-mark class="block h-9 w-auto"/>
        </a>
    </div>

    <!-- Navigation Links -->
    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="{{ route('dashboard') }}" :active="request()->routeIs('dashboard')">
            {{ __('Dashboard') }}
        </x-jet-nav-link>
    </div>

    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="{{ route('OrderContent.create') }}"
                        :active="request()->routeIs('Create Order')">
            {{ __('Create Order') }}
        </x-jet-nav-link>
    </div>

    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="#{{--{{ route('Scanned Order') }}--}}"
                        :active="request()->routeIs('Scanned Order')">
            {{ __('Scanned Order') }}
        </x-jet-nav-link>
    </div>

    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="#{{--{{ route('History') }}--}}" :active="request()->routeIs('History')">
            {{ __('History') }}
        </x-jet-nav-link>
    </div>

    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="#{{--{{ route('Help') }}--}}" :active="request()->routeIs('Help')">
            {{ __('Help') }}
        </x-jet-nav-link>
    </div>
    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="{{ route('location.index') }}" :active="request()->routeIs('Help')">
            {{ __('Location') }}
        </x-jet-nav-link>
    </div>
    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-jet-nav-link href="{{ route('status.index') }}" :active="request()->routeIs('Help')">
            {{ __('Status') }}
        </x-jet-nav-link>
    </div>
</div>



