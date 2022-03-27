# JsonlCompare

This is a Blazor WebAssembly Project to list and compare JSONs in a *.jsonl* file.

*jsonl* is a file format to store multiple unformatted JSON documents in a single file, delimited by a new-line. For more information, please see the [jsonlines.org](https://jsonlines.org/).

## Which problem does *JsonlCompare* solve?

*jsonl* is cool to store many related JSONs in one place, e.g. messages transmitted by a message bus. You could then compare the JSONs in a text editor.
But what if the messages do not share a rigid schema? As the number of JSONs in your *jsonl* file grows, it gets really cumbersome to find some shared properties and compare their values.
Sometimes it's just enough to have very short and very large strings for the same property to break the visual alignment hard enough to make you struggle.

Using ***JsonlCompare*** gives you back alignment for your JSONs and makes it easy to compare related properties.

## How does it solve the problem?

**JsonlCompare** flattens your *jsonl* file by extracting all distinct properties your JSON documents and their subdocuments have.
It makes use of [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) package to merge the documents and extracts all properties afterwards.
The flattend structure is put into a simple table structure. Properties, that do not exist in all documents are shown where they exist and skipped where they don't.
Additionally, **JsonlCompare** lets you select which properties to show in the table. So you can deselect all properties, that you are not interessed in.

## Usage & License

A version of this software is deployed at [jsonl.riedle-software.de](https://jsonl.riedle-software.de).
You can use this site for free but there are no guarantees on availability or stability of the site. **Note** that this project is still in **beta**. It might not cover all use cases.

The project is provided under **MIT License** and **as-is**. So feel free to fork it, download the code or the release package and host it on your own.

This is a Blazor WebAssembly project. No data is uploaded to the server. Your files will only be processed in your browser locally. It doesn't use any cookies.

## Demo

A version of this software is deployed at [jsonl.riedle-software.de](https://jsonl.riedle-software.de). To upload a file, Drag&Drop it to text box in the middle.
Your **jsonl** files are parsed and afterward shown in a table below the welcome text.
![All properties](/assets/AllProps.png)

Open the hamburger menu to find a nested list of properties. Here you can select which properties shall be shown in the table.
![Only some properties](/assets/OnlySomeProps.png)

Click on a row to show a formated version of the underlying JSON in the card to the right.
