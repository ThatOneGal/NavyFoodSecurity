<x-jet-form-section submit="updatePassword">
    <x-slot name="title">
        {{ __('Update Role') }}
    </x-slot>

    <x-slot name="description">
        {{ __('Change your role based on your current duties.') }}
    </x-slot>

    <x-slot name="form">
        <div class="col-span-6 sm:col-span-4">
            <x-jet-label for="current_role" value="{{ __('Current Password') }}" />
            <x-jet-select id="current_role" class="mt-1 block w-full" >
                @foreach($userRoleList as $userRole)

                    @if ($User->UserRoleId == $userRole->id)
                        <option value="{{$userRole->id}}" selected>{{$userRole->RoleName}}</option>

                    @else
                        <option value="{{$userRole->id}}" >{{$userRole->RoleName}}</option>

                    @endif
                @endforeach


            </x-jet-select>
            <x-jet-input-error for="current_password" class="mt-2" />
        </div>


    </x-slot>

    <x-slot name="actions">
        <x-jet-action-message class="mr-3" on="saved">
            {{ __('Saved.') }}
        </x-jet-action-message>

        <x-jet-button>
            {{ __('Save') }}
        </x-jet-button>
    </x-slot>
</x-jet-form-section>
