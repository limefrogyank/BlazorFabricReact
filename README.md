# Use Fabric React components in your Blazor app!

Here's how I managed to do it.  There's a Blazor web app and a Blazor component library in this repo.  Within the Blazor component library in a subdirectory, I used the dotnet CLI to create a simple React app.  

1.  The React app has been modified.  Instead of immediately creating the `<App>...</App>` component and everything in it, I'm creating factory functions that make the individual React components.  These are available on the global (window) property `reactFabric`.  Take a look at `BlazorFabricReact/BlazorFabricReact/src/index.tsx` to see some examples.  (There aren't many yet.)
2.  All React projects generally use Webpack, which automatically minifies/uglifies everything.  I had to turn that off because I want the functions I'm creating in the previous point to remain accessible to my Blazor app.  The names *cannot* be changed if you want to access them from Blazor.
3.  The "React app" must then be compiled via command line (i.e. `npm run build`).  The resulting `index_bundle.js` must then be copied over to the Blazor web app project.  There is already a reference to it in the `_Hosts.cshtml` file. 
4.  Each Fabric component factory function that is referenced in the React app under `reactFabric` must have a corresponding Blazor component razor file.  If you look at `PrimaryButton.razor`, it contains a single `div` where React will render the Primary Button content.  The `div` contains a ref which is passed to the javascript factory function along with all the properties that the React component expects.  In the button case, I created a C# equivalent of the typescript `IButtonProps` interface and made sure that it would serialize correctly using the appropriate Newtonsoft JsonConvert attributes.  All of the Blazor components parameters are then passed into this `ButtonProps` class which is sent along with the `div` reference.

## Drawbacks

1.  I suck at web development.  I need help making a proper webpack.config.json file that will minify everything **but** the functions I'm using as component factories.  Otherwise the javascript file will get too big.
2.  Ideally, there would be some type of script that checks what components you are actually using and only includes those into the javascript file.  
3.  I have no idea how to make `npm run build` run and copy the result on every blazor build.  It's all manual for now.
4.  I haven't done any performance checks.  No idea how well this will work in the long run, but it seems to work right now.

## Can you help?

Contact me and/or submit some pull requests!
