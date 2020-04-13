<template>
  <div>
    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <button type="button" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150" @click="open = !open">
          <div class="flex-1 text-left">
            Group
          </div>
          <div class="text-right">
            <svg class="-mr-1 ml-2 h-5 w-5 right-align" fill="currentColor" viewBox="0 0 20 20">
              <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd" />
            </svg>
          </div>
        </button>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input type="text" placeholder="Group Name" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="password">
          Password
        </label>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input type="password" name="password" placeholder="Password" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="password">
          Group name
        </label>
      </div>
    </div>

    <button type="submit" class="group relative w-full flex justify-center py-4 px-6 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-gray-800 hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-indigo active:bg-gray-700 transition duration-150 ease-in-out">
      VIEW PROFILES
    </button>
  </div>
</template>
