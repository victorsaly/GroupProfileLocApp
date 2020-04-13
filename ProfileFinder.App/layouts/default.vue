<template>
  <div class="w-full h-screen">
    <main class="text-center content-center min-h-full">
      <div class="mr-10 ml-10 pt-10 pb-20">
        <h1 class="text-4xl mb-5">
          <span class="text-gray-600">Profile</span><span class="text-bold">Finder</span>
        </h1>
        <nuxt />
      </div>
    </main>
    <div class="bottomNav fixed bottom-0 w-full">
      <nav style="border-top:1px solid #ccc" class="md:hidden bottom-0 w-full text-xs bg">
        <ul class="flex justify-around items-center text-black bg-white text-center opacity-75 text-lg font-bold">
          <li class="p-4 hover:bg-gray-500">
            <a href="/link">
              <svg class="h-10 w-6 fill-current mx-auto" viewBox="0 0 24 24" width="24" height="24">
                <path class="heroicon-ui" d="M13 20v-5h-2v5a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2v-7.59l-.3.3a1 1 0 1 1-1.4-1.42l9-9a1 1 0 0 1 1.4 0l9 9a1 1 0 0 1-1.4 1.42l-.3-.3V20a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2zm5 0v-9.59l-6-6-6 6V20h3v-5c0-1.1.9-2 2-2h2a2 2 0 0 1 2 2v5h3z" fill-rule="evenodd" />
              </svg>
            </a>
          </li>
          <li class="p-4 hover:bg-gray-500">
            <a href="/link">
              <svg class="h-10 w-6 fill-current mx-auto" viewBox="0 0 20 20">
                <path class="heroicon-ui" d="M16.32 14.9l5.39 5.4a1 1 0 0 1-1.42 1.4l-5.38-5.38a8 8 0 1 1 1.41-1.41zM10 16a6 6 0 1 0 0-12 6 6 0 0 0 0 12z" fill-rule="evenodd" />
              </svg>
            </a>
          </li>
          <li class="p-4 hover:bg-gray-500">
            <a href="/link">
              <svg class="h-10 w-6 fill-current mx-auto" viewBox="0 0 20 20">
                <path class="heroicon-ui" d="M6 14H4a2 2 0 0 1-2-2V4c0-1.1.9-2 2-2h12a2 2 0 0 1 2 2v2h2a2 2 0 0 1 2 2v13a1 1 0 0 1-1.7.7L16.58 18H8a2 2 0 0 1-2-2v-2zm0-2V8c0-1.1.9-2 2-2h8V4H4v8h2zm14-4H8v8h9a1 1 0 0 1 .7.3l2.3 2.29V8z" fill-rule="evenodd" />
              </svg>
            </a>
          </li>
          <li class="p-4 hover:bg-gray-500">
            <a href="/link">
              <svg class="h-10 w-8 fill-current mx-auto" viewBox="0 0 24 24">
                <path class="heroicon-ui" d="M12 12a5 5 0 1 1 0-10 5 5 0 0 1 0 10zm0-2a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm9 11a1 1 0 0 1-2 0v-2a3 3 0 0 0-3-3H8a3 3 0 0 0-3 3v2a1 1 0 0 1-2 0v-2a5 5 0 0 1 5-5h8a5 5 0 0 1 5 5v2z" fill-rule="evenodd" />
              </svg>
            </a>
          </li>
        </ul>
      </nav>
    </div>
  </div>
</template>

<style>
html {
  font-family: 'Source Sans Pro', -apple-system, BlinkMacSystemFont, 'Segoe UI',
    Roboto, 'Helvetica Neue', Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
}

*,
*:before,
*:after {
  box-sizing: border-box;
  margin: 0;
}

.button--green {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #3b8070;
  color: #3b8070;
  text-decoration: none;
  padding: 10px 30px;
}

.button--green:hover {
  color: #fff;
  background-color: #3b8070;
}

.button--grey {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #35495e;
  color: #35495e;
  text-decoration: none;
  padding: 10px 30px;
  margin-left: 15px;
}

.button--grey:hover {
  color: #fff;
  background-color: #35495e;
}

.label-floating input:not(:placeholder-shown) {
  padding-top: 1.4rem;
  margin-bottom: 0;
}
.label-floating input:not(:placeholder-shown) ~ label {
  font-size: 0.6rem;
  transition: all 0.2s ease-in-out;
  color: #1f9d55;
  display: inline;
  position: absolute;
  top: 10px;
  left: 25px;
}
</style>
